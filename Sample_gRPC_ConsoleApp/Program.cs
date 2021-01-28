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

            Console.WriteLine("");

            // my function
            string requestText = "MyRequest";
            Int32 intValue = 23;

            MyRequest myRequest = new MyRequest();
            myRequest.Parameter1 = requestText;
            myRequest.ParameterIntValue = intValue;

            var reply = client.MyFunction(myRequest);

            Console.WriteLine("MyFunction: " + reply.Message);

            Console.WriteLine("");

            // calc function
            Int32 intValue1 = 50;
            Int32 intValue2 = 5;

            var replyCalc = client.Calc(
                new CalcParameter { Parameter1 = intValue1, Parameter2 = intValue2 }
                );

            Console.WriteLine("Calc 結果");
            Console.WriteLine("　加算=" + replyCalc.Addition);
            Console.WriteLine("　減算=" + replyCalc.Subtraction);
            Console.WriteLine("　掛算=" + replyCalc.Multiplication);
            Console.WriteLine("　割算=" + replyCalc.Division);
        }
    }
}
