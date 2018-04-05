using HoloToolkit.Unity.InputModule;

using UnityEngine;
using UnityEngine.UI;

public class SensorInteractionManager : MonoBehaviour, IInputClickHandler
{
    public void OnInputClicked(InputClickedEventData eventData)
    {
        var textControl = this.gameObject.GetComponentInChildren<Text>();
        var sensorNumber = this.gameObject.tag;
        var data = new WebBridge().GetHumidityRecord(sensorNumber);
        textControl.text = "Reported value " + data.Value + " @ " + data.TimestampUtc.ToString("g");
    }
}