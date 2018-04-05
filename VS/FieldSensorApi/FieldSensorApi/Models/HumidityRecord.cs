using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FieldSensorApi.Models
{
    public class HumidityRecord
    {
        public string Id { get; set; }
        public DateTime TimestampUtc { get; set; }
        public double Value { get; set; }
    }
}