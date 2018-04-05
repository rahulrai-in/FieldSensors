using Newtonsoft.Json;

using UnityEngine;

public class WebBridge
{
    public HumidityRecord GetHumidityRecord(string sensorId)
    {
        var www = new WWW("https://azurewebapphostname/api/1?r=" + Random.Range(0, 9999));
        WaitForSeconds w;
        while (!www.isDone)
            w = new WaitForSeconds(0.1f);

        var sensorData = www.text;
        var humidityRecord = JsonConvert.DeserializeObject<HumidityRecord>(sensorData);
        return humidityRecord;
    }
}