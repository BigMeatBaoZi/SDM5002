using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class JointsStateReceiverOSC : MonoBehaviour
{
    public GameObject OSCManager;
    public string Address;

    OSCReceiver m_OSCReceiver;
    ArticulationBody[] m_JointArticulationBodies;

    [SerializeField]
    GameObject m_MyCobot;

    static readonly string[] m_LinkNames =
        { "world/joint1/joint2", "/joint3", "/joint4", "/joint5", "/joint6" , "/joint6_flange"};

    // Hardcoded variables
    const int k_NumRobotJoints = 6;

    void Start()
    {
        // Get articulation bodies from arm
        m_JointArticulationBodies = new ArticulationBody[k_NumRobotJoints];
        
        var linkName = string.Empty;
        for (var i = 0; i < k_NumRobotJoints; i++)
        {
            linkName += m_LinkNames[i];
            m_JointArticulationBodies[i] = m_MyCobot.transform.Find(linkName).GetComponent<ArticulationBody>();
        }

        // Get OSC receiver
        m_OSCReceiver = OSCManager.GetComponent<OSCReceiver>();

        // Bind msg address and callback
        m_OSCReceiver.Bind(Address, OnMsgRecv);
    }

    protected void OnMsgRecv(OSCMessage msg)
    {
        Debug.Log(msg);
        for (var joint = 0; joint < m_JointArticulationBodies.Length; joint++)
        {
            var joint1XDrive = m_JointArticulationBodies[joint].xDrive;
            joint1XDrive.target = msg.Values[joint].FloatValue;
            m_JointArticulationBodies[joint].xDrive = joint1XDrive;
        }
    }

}
