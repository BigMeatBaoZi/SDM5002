# Manual manipulation with feedback to Unity 
import time
from pythonosc import udp_client
from pymycobot.mycobot import MyCobot

server_ip = "127.0.0.1"
server_port = 7000

msg_address = "/joint_states"

if __name__ == '__main__':
    # Start OSC client
    osc_client = udp_client.SimpleUDPClient(server_ip, server_port)
    
    # Arm release
    arm = MyCobot("COM3", 115200)
    arm.release_all_servos()
    while True:
        joints_info = arm.get_angles()
        osc_client.send_message(msg_address, joints_info)
        print("Joints: {}".format(joints_info))
        # time.sleep(0.1)
