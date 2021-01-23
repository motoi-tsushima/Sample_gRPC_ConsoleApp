using System;
using Grpc.Net.Client;

namespace Sample_gRPC_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var response = client.SayHello(new HelloRequest { Name = "Motoi.Tsushima" });
            //var response = client.SayHelloAsync(new HelloRequest { Name = "World" });

            Console.WriteLine("Greeting: " + response.Message);
        }
    }
}
