from pymycobot.mycobot import MyCobot

if __name__ == '__main__':
    arm = MyCobot("COM3", 115200)
    arm.release_all_servos()
    while True:
        pose_info = arm.get_coords()
        print("Pose: {}".format(pose_info))
        # time.sleep(0.5)