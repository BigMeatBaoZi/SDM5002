
<img src="docs/fig/image2022-3-13_21-54-9.png" alt="image2022-3-13_21-54-9" width="500px" />

# VR Controlled Robot Arm

[![Asculus: SDM5002 (shields.io)](https://img.shields.io/badge/Asculus-SDM5002-red)](https://github.com/JoeyWu-tech/SDM5002) [![SDIM: SUSTECH (shields.io)](https://img.shields.io/badge/SDIM-SUSTECH-green)](https://sdim.sustech.edu.cn/) [![Windows: Pass (shields.io)](https://img.shields.io/badge/Windows-Pass-yellow)]()

This a course project in SDM5002. We team built a system to use VR to control robot arm it called **Asculus** .

This repository contains:

1. The background of our projects and motivation.
2. Hardware and the configuration of our projects 
3. The tutorial to use our project
4. The code we used 
5. Our individual code/ CAD model / personal report

## Background

In SDM5002, we were required to explore our interested project without any limit. After a series technology survey and competitive product survey,  we **focused our application on the emergency**
**rescue of cardiac arrest patients.** In our imagination, medical professionals can use VR to control AEDs for first aids.

## Environment

The hardware we used :

* VR : Oculus Quest 2 
* Robot Arm :
* Lidar : RealSense d435
*  Chassis :

Software version 

* Windows 11

* Unity 2021.3.2f1c1 (64bit)

* Visual Studio 2017

* Oculus Home 

  



## Prerequisite

For robot arm control client (written in Python3)

* [pyserial](https://pypi.org/project/pyserial/): for serial port communication
* [ikpy](https://github.com/Phylliade/ikpy): inverse kinematics solver
* [pythonosc](https://pypi.org/project/python-osc/): Open Sound Control server and client implementations in pure python

## Usage

1. Start the robot arm control client

```shell
python3 target_ctrl.py
```

2. Start the Unity project

## Contributing

* Jing Yonglin
* Zhou Jinhui
* Chen Kezhou
* Zhang Yueyue
* Wu Yin



## License

[MIT](LICENSE) © Richard Littauer
