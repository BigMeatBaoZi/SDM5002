import math
from typing import List

import ikpy.chain

import numpy as np

class IKProvider:
    def __init__(self, urdf_path) -> None:
        print('[IKProvider] URDF path: {}'.format(urdf_path))
        self.chain = ikpy.chain.Chain.from_urdf_file(urdf_path)

    def IKPosition(self, target:List[float]) -> List[float]:
        res_ik = self.chain.inverse_kinematics(target)
        res_fk = self.chain.forward_kinematics(res_ik)[:3, 3]

        print('[IKProvider] Computed position vector : {}, original position vector : {}'.format(res_fk, target))

        return RadToDeg(res_ik[1:])

    def IKPose(self, postion:List[float], orient:List[float], mode:str) -> List[float]:
        res_ik = self.chain.inverse_kinematics(postion, orient, mode)
        res_fk = self.chain.forward_kinematics(res_ik)[:3, 3]

        print('[IKProvider] Computed position vector : {}, original position vector : {}'.format(res_fk, postion))

        return RadToDeg(res_ik[1:])

def RadToDeg(src:List[float]) -> List[float]:
    kRad2Deg = 180.0 / math.pi
    res = list()
    for e in src:
        res.append(e * kRad2Deg)
    return res

def MilimeterToMeter(src:List[float]) -> List[float]:
    res = list()
    for e in src:
        res.append(e * 0.001)
    return res