using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimArmController : MonoBehaviour
{
    // Hardcoded variables
    const int k_NumRobotJoints = 6;
    const float k_JointAssignmentWait = 0.1f;

    public static readonly string[] LinkNames =
        { "world/joint1/joint2", "/joint3", "/joint4", "/joint5", "/joint6" , "/joint6_flange"};

    [SerializeField]
    GameObject m_MyCobot;

    [SerializeField]
    List<float> m_TargetJointAngle = new List<float>();

    ArticulationBody[] m_JointArticulationBodies;

    void Start()
    {
        m_JointArticulationBodies = new ArticulationBody[k_NumRobotJoints];

        var linkName = string.Empty;
        for (var i = 0; i < k_NumRobotJoints; i++)
        {
            linkName += LinkNames[i];
            m_JointArticulationBodies[i] = m_MyCobot.transform.Find(linkName).GetComponent<ArticulationBody>();
        }
    }

    public void ExecuteJointCmd()
    {
        Debug.Log(string.Join(",", m_TargetJointAngle));
        for (var joint = 0; joint < m_JointArticulationBodies.Length; joint++)
        {
            var joint1XDrive = m_JointArticulationBodies[joint].xDrive;
            joint1XDrive.target = m_TargetJointAngle[joint];
            m_JointArticulationBodies[joint].xDrive = joint1XDrive;
        }
    }
}
