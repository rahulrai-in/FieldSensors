using System.Text;

using HoloToolkit.Unity;

using Newtonsoft.Json;

using UnityEngine;
using UnityEngine.Networking;

public class AzureBridge
{
    public HumidityRecord GetHumidityRecord(string sensorId)
    {
        WWW www = new WWW("http://demo5687390.mockable.io/1?r=" + Random.Range(0, 9999));
        WaitForSeconds w;
        while (!www.isDone)
            w = new WaitForSeconds(0.1f);

        var sensorData = www.text;
        var humidityRecord = JsonConvert.DeserializeObject<HumidityRecord>(sensorData);
        return humidityRecord;
    }
}