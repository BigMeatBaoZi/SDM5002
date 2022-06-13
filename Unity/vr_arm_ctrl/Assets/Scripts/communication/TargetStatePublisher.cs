using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using extOSC;

public class TargetStatePublisher : MonoBehaviour
{
    public GameObject OSCManager;
    public string TransmitAddress;

    OSCTransmitter m_OSCTransmitter;

    [SerializeField]
    GameObject m_Target;

    // Start is called before the first frame update
    void Start()
    {
        // Get OSC transmitter
        m_OSCTransmitter = OSCManager.GetComponent<OSCTransmitter>();
    }

    public void Publish() 
    {
        // https://github.com/Unity-Technologies/Unity-Robotics-Hub/blob/a72ef3af0573e6f9ce06e726f17e4ba125738fe8/tutorials/pick_and_place/Scripts/SourceDestinationPublisher.cs#L62
        // Unity coordinate to URDF(ROS) coordinate (no ROS involved)
        var target_position = m_Target.transform.position.To<FLU>();
        var target_rot = m_Target.transform.eulerAngles.To<FLU>();

        // Create message
        var msg = new OSCMessage(TransmitAddress);
        // Populate message
        msg.AddValue(OSCValue.Float(target_position.x)); // In meters
        msg.AddValue(OSCValue.Float(target_position.y));
        msg.AddValue(OSCValue.Float(target_position.z));
        msg.AddValue(OSCValue.Float(MapDegree(target_rot.x)));
        msg.AddValue(OSCValue.Float(MapDegree(target_rot.y)));
        msg.AddValue(OSCValue.Float(MapDegree(target_rot.z)));

        m_OSCTransmitter.Send(msg);
    }

    float MapDegree(float deg)
    {
        float result = deg;

        if (result > 360.0f) 
        {
            while (result > 360.0f)
            {
                result -= 360.0f;
            }
        }

        if (result < 0.0f)
        {
            while (result < 0.0f)
            {
                result += 360.0f;
            }
        }

        return result - 180.0f;

    }
    
}
