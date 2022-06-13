from pymycobot.mycobot import MyCobot

from ik_provider import MilimeterToMeter
from ik_provider import IKProvider

if __name__ == '__main__':
    arm = MyCobot("COM3", 115200)

    ikp = IKProvider('./mycobot_desc/mycobot_urdf.urdf')
    target_pose = [0.05, -0.1, 0.3]
    target_orient = [0, 0, -1]
    # target_jangles = ikp.IKPosition(target_pose)
    target_jangles = ikp.IKPose(target_pose, target_orient, 'Z')
    print(target_jangles)

    arm.send_angles(target_jangles, 20)