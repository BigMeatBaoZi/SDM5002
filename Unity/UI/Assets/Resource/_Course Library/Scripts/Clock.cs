using UnityEngine;
using System;

public class Clock : UnityEngine.MonoBehaviour 
{
    const float degressPerHour = 30f;
    const float degressPerMinutes = 6f;
    const float degressPerSeconds = 6f;
    public Transform hoursTransform;
    public Transform minutesTransform;
    public Transform secondsTransform;

    public bool continuous;

    void UpdateContinuous()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursTransform.localRotation = Quaternion.Euler((float)time.TotalHours * degressPerHour, 0f, 0f);
        minutesTransform.localRotation = Quaternion.Euler((float)time.TotalMinutes * degressPerMinutes, 0f, 0f);
        secondsTransform.localRotation = Quaternion.Euler((float)time.TotalSeconds * degressPerSeconds, 0f, 0f);
    }

    void UpdateDiscrete()
    {
        DateTime time = DateTime.Now;
        hoursTransform.localRotation = Quaternion.Euler(time.Hour * degressPerHour, 0f, 0f);
        minutesTransform.localRotation = Quaternion.Euler(time.Minute * degressPerMinutes, 0f, 0f);
        secondsTransform.localRotation = Quaternion.Euler(time.Second * degressPerSeconds, 0f, 0f);
    }

    void Update()
    {
        if (continuous)
        {
            UpdateContinuous();
        }
        else
        {
            UpdateDiscrete();
        }
    }
}

