using System;
using System.Collections;
using System.Collections.Generic;

using HoloToolkit.Unity.InputModule;

using UnityEngine;
using UnityEngine.UI;

public class SensorInteractionManager : MonoBehaviour, IInputClickHandler
{
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        var textControl = gameObject.GetComponentInChildren<Text>();
        var sensorNumber = this.gameObject.tag;
        var data = new AzureBridge().GetHumidityRecord(sensorNumber);
        textControl.text = "Reported value " + data.Value + " @ " + data.TimestampUtc.ToString("g");
    }
}