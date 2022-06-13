using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class OSCMsgSender : MonoBehaviour
{
    public GameObject OSCManager;

    public string Address;

    OSCTransmitter m_OSCTransmitter;
    OSCMessage m_Message;

    float m_LastSendTime = 0.0f;

    void Start()
    {
        m_Message = new OSCMessage(Address);

        // Populate values.
        m_Message.AddValue(OSCValue.Float(0.213f));
        m_Message.AddValue(OSCValue.Float(1.231f));
        m_Message.AddValue(OSCValue.Float(22.21f));

        // Get OSC transmitter
        m_OSCTransmitter = OSCManager.GetComponent<OSCTransmitter>();
    }

    void Update()
    {   if (Time.realtimeSinceStartup - m_LastSendTime > 2.0f) {
            m_OSCTransmitter.Send(m_Message);
            m_LastSendTime = Time.realtimeSinceStartup;
        }
    }
}
