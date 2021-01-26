using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace Exercise
{
    class Program
    {

        static async Task Main(string[] args)
        {
            string topic = "test";
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:29092",
                Partitioner = Partitioner.Murmur2
            };

            using var p = new ProducerBuilder<string, string>(config).Build();

            for (var i = 0; i < 100; i++)
            {
                var msg = new Message<string, string>
                {
                    Key = i % 2 == 0 ? "even" : "odd",
                    Value = $"Message #{i}"
                };

                var dr = await p.ProduceAsync(topic, msg);
                Console.WriteLine($"Produced '{dr.Key}'-'{dr.Value}' to topic {dr.Topic}, partition {dr.Partition}, offset {dr.Offset}");
            }

            Console.ReadKey();
        }
    }
}
