from pymycobot.mycobot import MyCobot
import time

mc=MyCobot('COM15',115200)
# flag = mc.is_gripper_moving()
# print("Is gripper moving: {}".format(flag))
val=0
val=input()
if val==1:
# 设置夹爪的状态，让其以70的速度快速打开爪子
    mc.set_gripper_value(99, 70)
    time.sleep(3)
if val==2:
# 设置夹爪的状态，让其以70的速度快速收拢爪子(tips:夹爪的范围是20-99，不是官网写的0-255)
    mc.set_gripper_value(20, 70)
    time.sleep(3)