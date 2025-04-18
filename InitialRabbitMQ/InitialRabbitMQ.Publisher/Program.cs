﻿//At first we need a library (nuget pack.) that communicate with RabbitMQ --> RabbitMQ.Client

#region Connection And Channel Arrangements
//If I want to send data to rabbitmq i need to provide a connection
var factory = new ConnectionFactory();
//We get that url from rabbitmq cloud
factory.Uri = new Uri("amqps://praqhwrl:FlL17KQ2pUS2kKznDABu8LtzdDDZ3jER@toad.rmq.cloudamqp.com/praqhwrl");

using var connection = factory.CreateConnection();
var channel = connection.CreateModel();
channel.QueueDeclare("initial-queue", true, false, false);
#endregion Connection And Channel Arrangements

#region Publish Message Arrangements
//we send messages to the queue as byte so that we can sen every kind of data (pdf,img etc.). We need to convert it to byte.
string message = "first message";
var messageBody = Encoding.UTF8.GetBytes(message);
#endregion Publish Message Arrangements

//string.Empty make exchange as default exchange so we need to give queue name so default exchange send message to related queue
channel.BasicPublish(string.Empty, "initial-queue", null, messageBody);

Console.WriteLine("Message sent.");
Console.ReadLine();