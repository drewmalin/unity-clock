using System;
using UnityEngine;

public class Clock : MonoBehaviour {

    public Transform hoursTransform, minutesTransform, secondsTransform;
    public string timeZoneId;
    public bool smooth;

    const float
        degreesPerHour = 30f,
        degreesPerMinute = 6f,
        degreesPerSecond = 6f;

    private void Update()
    {
        TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        DateTime time = TimeZoneInfo.ConvertTime(DateTime.Now, timeZone);
        if (smooth)
        {
            RotateHandsSmooth(time);
        }
        else
        {
            RotateHandsTick(time);
        }
   
    }

    private void RotateHandsSmooth(DateTime time)
    {
        TimeSpan now = time.TimeOfDay;
        RotateHourHand((float) now.TotalHours);
        RotateMinuteHand((float) now.TotalMinutes);
        RotateSecondHand((float) now.TotalSeconds);
    }

    private void RotateHandsTick(DateTime time)
    {
        RotateHourHand(time.Hour);
        RotateMinuteHand(time.Minute);
        RotateSecondHand(time.Second);
    }

    private void RotateHourHand(float degrees)
    {
        this.hoursTransform.localRotation =
            Quaternion.Euler(0f, degrees * degreesPerHour, 0f);
    }

    private void RotateMinuteHand(float degrees)
    {
        this.minutesTransform.localRotation =
            Quaternion.Euler(0f, degrees * degreesPerMinute, 0f);
    }

    private void RotateSecondHand(float degrees)
    {
        this.secondsTransform.localRotation = 
            Quaternion.Euler(0f, degrees * degreesPerSecond, 0f);
    }
}
