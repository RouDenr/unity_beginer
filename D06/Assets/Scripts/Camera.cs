using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public alarm Alarm;

    private void OnTriggerEnter(Collider other)
    {
        Alarm.playerUnderCamera = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Alarm.playerUnderCamera = false;
    }
}
