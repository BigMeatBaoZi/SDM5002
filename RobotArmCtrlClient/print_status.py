from pymycobot.mycobot import MyCobot

if __name__ == '__main__':
    arm = MyCobot("COM3", 115200)
    angle_datas = arm.get_angles()
    coords = arm.get_coords()

    print("Joint status (dgrees): {}".format(angle_datas))
    print("End pose [x,y,z,rx,ry,rz]: {}".format(coords))