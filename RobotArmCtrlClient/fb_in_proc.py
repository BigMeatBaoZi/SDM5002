import time

from pymycobot.mycobot import MyCobot

joint_conf_1 = [0, 0, 0, 0, 0, 0]
joint_conf_2 = [88.68, -138.51, 155.65, -128.05, -9.93, -15.29]
pose_conf_1 = [59.9, -65.8, 250.7, -50.99, 83.14, -52.42]
speed = 30

def PrintStatusBeforeFinishJoints(arm : MyCobot, target_joints : list, speed : float, print_freq : float):
    print_elapse = 1 / print_freq
    arm.send_angles(target_joints, speed)
    while not arm.is_in_position(target_joints, 0):
        print("Joints: {}".format(arm.get_angles()))
        time.sleep(print_elapse)
    
    print("Target finish")

def PrintStatusBeforeFinishPose(arm : MyCobot, target_pose : list, speed : float, print_freq : float):
    print_elapse = 1 / print_freq
    arm.send_coords(target_pose, speed, 1)
    while not arm.is_in_position(target_pose, 1):
        print("Pose: {}".format(arm.get_coords()))
        time.sleep(print_elapse)
    
    print("Target finish")

if __name__ == '__main__':
    arm = MyCobot("COM3", 115200)
    PrintStatusBeforeFinishJoints(arm, joint_conf_2, speed, 10)
    PrintStatusBeforeFinishPose(arm, pose_conf_1, speed, 10)
    PrintStatusBeforeFinishJoints(arm, joint_conf_1, speed, 10)