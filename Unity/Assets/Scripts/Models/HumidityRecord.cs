using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HumidityRecord
{
    public string Id { get; set; }
    public DateTime TimestampUtc { get; set; }
    public double Value { get; set; }
}