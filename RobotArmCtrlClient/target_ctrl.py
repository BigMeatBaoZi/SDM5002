import time
import threading
import signal
import sys

from pythonosc import dispatcher
from pythonosc import osc_server
from pythonosc import udp_client

from pymycobot.mycobot import MyCobot

from ik_provider import IKProvider

class StateReportThread(threading.Thread):
    def __init__(self):
        threading.Thread.__init__(self)
        self.stop_flag = False

    def run(self):
        while not self.stop_flag:
            arm_lck.acquire(blocking=True)
            joints_info = arm.get_angles()
            # print("Joints: {}".format(arm.get_angles()))
            arm_lck.release()
            osc_client.send_message(joint_state_msg_addr, joints_info)
            time.sleep(0.002)

def sigint_handler(sig, frame):
    print("SIGINT captured, exit program")
    report_thread.stop_flag = True
    report_thread.join()
    sys.exit(0)

def OnTargetStateRecv(unused_addr, x, y, z, x_rot, y_rot, z_rot):
    print("Msg: {} {} {} {} {} {}".format( x, y, z, x_rot, y_rot, z_rot))

    target_position = [x, y, z]
    target_orient = [0, 0, -1]
    target_joint_angles = ikp.IKPose(target_position, target_orient, 'Z')

    arm_lck.acquire(blocking=True)
    arm.send_angles(target_joint_angles, arm_speed)
    arm_lck.release()

def OnGripperCtrlRecv(unused_addr, open):
    # true -> open
    # false -> close

    open_val = 60
    close_val = 30

    gripper_spd = 50

    if(open):
        arm_lck.acquire(blocking=True)
        arm.set_gripper_value(open_val, gripper_spd)
        arm_lck.release()
    else:
        arm_lck.acquire(blocking=True)
        arm.set_gripper_value(close_val, gripper_spd)
        arm_lck.release()

unity_server_ip = "127.0.0.1"
unity_server_port = 7000

client_server_ip = "127.0.0.1"
client_server_port = 7001

target_msg_addr = "/target_state"
joint_state_msg_addr = "/joint_states"
gripper_ctrl_msg_addr = "/gripper_ctrl"

# Signal capture
signal.signal(signal.SIGINT, sigint_handler)

# Inverse kinematic computer
urdf_path = './mycobot_desc/mycobot_urdf.urdf'
ikp = IKProvider(urdf_path)

# Arm
global arm
arm = MyCobot("COM3", 115200)
arm_speed = 30

# Thread sync variable
arm_lck = threading.Lock()

# Power arm
if not arm.is_power_on():
    arm.power_on()

# Start OSC client
osc_client = udp_client.SimpleUDPClient(unity_server_ip, unity_server_port)

# Start state report thread
global report_thread 
report_thread = StateReportThread()
report_thread.daemon = True
report_thread.start()

# Start OSC sever
disp = dispatcher.Dispatcher()
disp.map(target_msg_addr, OnTargetStateRecv)
disp.map(gripper_ctrl_msg_addr, OnGripperCtrlRecv)
server = osc_server.BlockingOSCUDPServer((client_server_ip, client_server_port), disp)
print("Serving on {}".format(server.server_address))
server.serve_forever()