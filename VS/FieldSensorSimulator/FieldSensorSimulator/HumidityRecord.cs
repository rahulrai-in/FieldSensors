namespace FieldSensorSimulator
{
    using System;

    public class HumidityRecord
    {
        public string Id { get; set; }
        public DateTime TimestampUtc { get; set; }
        public double Value { get; set; }
    }
}