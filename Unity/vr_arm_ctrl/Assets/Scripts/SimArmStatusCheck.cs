using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.UrdfImporter;
using UnityEngine;

public class SimArmStatusCheck : MonoBehaviour
{
    const int k_NumRobotJoints = 6;

    public static readonly string[] LinkNames =
        { "world/joint1/joint2", "/joint3", "/joint4", "/joint5", "/joint6" , "/joint6_flange"};

    public float LogElapse = 0.5f;

    [SerializeField]
    GameObject m_MyCobot;

    // Robot Joints
    UrdfJointRevolute[] m_JointArticulationBodies;

    private float lastLogTime = 0.0f;

    void Start()
    {
        m_JointArticulationBodies = new UrdfJointRevolute[k_NumRobotJoints];

        var linkName = string.Empty;
        for (var i = 0; i < k_NumRobotJoints; i++)
        {
            linkName += LinkNames[i];
            m_JointArticulationBodies[i] = m_MyCobot.transform.Find(linkName).GetComponent<UrdfJointRevolute>();
        }
    }

    void Update()
    {
        if (Time.realtimeSinceStartup - lastLogTime > LogElapse)
        {
            float[] joints_angle = new float[6];
            for (int i = 0; i < k_NumRobotJoints; ++i) 
            {
                joints_angle[i] = m_JointArticulationBodies[i].GetPosition();
            }
            Debug.Log(string.Join(",", joints_angle));
            lastLogTime = Time.realtimeSinceStartup;
        }
    }
}
