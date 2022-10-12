using var channel = GrpcChannel.ForAddress("https://localhost:7021");
var client = new Greeter.GreeterClient(channel);
var reply = client.SayHello(new HelloRequest { Name = "GreeterClient" });

Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
