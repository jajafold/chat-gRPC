using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                new HelloRequest {Name = "GreeterClient"});
            var reply2 = await client.SaySmthAsync(new SimpleMessage {Message = "123"});
            Console.WriteLine("Greeting: " + reply2.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}