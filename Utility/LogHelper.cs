using System;
using Confluent.Kafka;

namespace study.Utility
{
	public class LogHelper
	{
        public static void Writelog(string topic,string message,string type )
        {
            var config = new ProducerConfig { BootstrapServers = LogKafka.BrokerList };
            using (var p = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {

                    p.Produce(topic, new Message<Null, string> { Value = type + message });
                    p.Flush();
                }
                catch (ProduceException<Null, string> e)
                {
                    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }
        }
    }
}

