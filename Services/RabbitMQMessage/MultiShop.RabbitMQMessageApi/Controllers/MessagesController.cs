using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MultiShop.RabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateMessage()
        {
            
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("Que2", false, false, false, arguments: null);
            var messageContent = "Merhaba yarram bu kurs için az daha beter bir kurs";
            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);

            channel.BasicPublish(exchange: "", routingKey: "Que2", basicProperties: null, body: byteMessageContent);

            return Ok("Mesajınız kuyruğa alınmıştır.");
        }
        private static string message;
        [HttpGet]
        public IActionResult GetMessage()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, body) =>
            {
                var byteMessage = body.Body.ToArray();
                message = Encoding.UTF8.GetString(byteMessage);
            };
            channel.BasicConsume(queue:"Que2",autoAck:false,consumer:consumer);

            if (string.IsNullOrEmpty(message))
            {
                return NoContent();
            }
            return Ok(message);
        }
    }
}
