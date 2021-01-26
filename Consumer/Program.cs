﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;


namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            string topic = "test";
            string groupId = "text-consumer-group1";

            var config = new ConsumerConfig
            {
                GroupId = groupId,
                BootstrapServers = "localhost:29092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var c = new ConsumerBuilder<string, string>(config).Build();
            c.Subscribe(topic);

            // Because Consume is a blocking call, 
            // we want to capture Ctrl+C and use a cancellation token 
            // to get out of our while loop and close the consumer gracefully.
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
            };

            try
            {
                while (true)
                {
                    // Consume a message from the test topic. 
                    // Pass in a cancellation token so we can break out of our loop when Ctrl+C is pressed
                    var cr = c.Consume(cts.Token);
                    Console.WriteLine($"Consumed, '{cr.Message.Key}'-'{cr.Message.Value}' from topic {cr.Topic}, partition {cr.Partition}, offset {cr.Offset}");

                    // Do something interesting with the message you consumed
                }
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                c.Close();
            }

        }
    }
}
