using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class OSCMsgReceiver : MonoBehaviour
{
    public GameObject OSCManager;

    public string Address;

    OSCReceiver m_OSCReceiver;

    void Start()
    {
        // Get OSC receiver
        m_OSCReceiver = OSCManager.GetComponent<OSCReceiver>();

        // Bind msg address and callback
        m_OSCReceiver.Bind(Address, OnMsgRecv);
    }

    protected void OnMsgRecv(OSCMessage msg)
    {
        Debug.Log(msg);
    }
}
