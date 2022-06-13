from sympy import true
from pymycobot.mycobot import MyCobot
import time

mc=MyCobot('COM3',115200)

# while true:
#     print(mc.get_gripper_value())
#     time.sleep(0.3)

print(mc.get_gripper_value())

# Open gripper
mc.set_gripper_value(60, 50)
print("open")
time.sleep(1)
print(mc.get_gripper_value())

# Close gripper
mc.set_gripper_value(25, 50)
print("close")
time.sleep(1)
print(mc.get_gripper_value())