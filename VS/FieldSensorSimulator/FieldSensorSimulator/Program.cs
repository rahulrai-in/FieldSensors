using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldSensorSimulator
{
    using Microsoft.Azure.EventHubs;

    internal class Program
    {
        private const string EhConnectionString = "Endpoint=sb://EVENTHUBNAMESPACE.servicebus.windows.net/;SharedAccessKeyName=Key";

        private const string EhEntityPath = "EVENT HUB NAME";

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Number of messages? ");
                var numberOfMessages = Convert.ToInt32(Console.ReadLine());
                SendMessagesToEventHub(numberOfMessages).Wait();
            }
        }

        private static async Task SendMessagesToEventHub(int numMessagesToSend)
        {
            var connectionStringBuilder = new EventHubsConnectionStringBuilder(EhConnectionString)
            {
                EntityPath = EhEntityPath
            };

            var eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder.ToString());
            Random random = new Random();
            for (var i = 0; i < numMessagesToSend; i++)
            {
                try
                {
                    var sensor1Record = new HumidityRecord
                    {
                        Id = "1",
                        TimestampUtc = DateTime.UtcNow,
                        Value = random.NextDouble() * 100
                    };
                    var sensor2Record = new HumidityRecord
                    {
                        Id = "2",
                        TimestampUtc = DateTime.UtcNow + TimeSpan.FromSeconds(random.Next(500)),
                        Value = random.NextDouble() * 100
                    };
                    var message = $"Message {i}: {Newtonsoft.Json.JsonConvert.SerializeObject(sensor1Record)} & {Newtonsoft.Json.JsonConvert.SerializeObject(sensor2Record)}";
                    Console.WriteLine($"Sending message: {message}");
                    await eventHubClient.SendAsync(new
                        EventData(Encoding.UTF8.GetBytes
                        (Newtonsoft.Json.JsonConvert.SerializeObject(sensor1Record))));
                    await eventHubClient.SendAsync(new
                        EventData(Encoding.UTF8.GetBytes
                            (Newtonsoft.Json.JsonConvert.SerializeObject(sensor2Record))));
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"{DateTime.Now} > Exception:{ exception.Message}");
                }
                await Task.Delay(1000);
            }

            Console.WriteLine($"{numMessagesToSend} messages sent.");
        }
    }
}