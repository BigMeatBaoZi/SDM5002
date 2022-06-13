using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using extOSC;

public class GripperCtrlPublisher : MonoBehaviour
{
    public GameObject OSCManager;
    public string TransmitAddress;

    public InputActionReference gripperReleaseRef = null;
    public InputActionReference gripperGrabRef = null;

    OSCTransmitter m_OSCTransmitter;

    void Start()
    {
        gripperReleaseRef.action.started += OnGripperReleaseCmd;
        gripperGrabRef.action.started += OnGripperGrabCmd;

        m_OSCTransmitter = OSCManager.GetComponent<OSCTransmitter>();
    }

    void OnGripperReleaseCmd(InputAction.CallbackContext context) 
    {
        SendGripperCtrlCmd(true);
        Debug.Log("Gripper release cmd send");
    }

    void OnGripperGrabCmd(InputAction.CallbackContext context)
    {
        SendGripperCtrlCmd(false);
        Debug.Log("Gripper grab cmd send");
    }

    void SendGripperCtrlCmd(bool cmd)
    {
        // true -> release
        // false -> grab

        var msg = new OSCMessage(TransmitAddress);
        msg.AddValue(OSCValue.Bool(cmd));
        m_OSCTransmitter.Send(msg);
    }
}
