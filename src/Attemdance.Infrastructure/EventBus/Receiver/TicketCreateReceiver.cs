using Attemdance.Domain.Entities;
using Attemdance.Domain.Interfaces.Services;
using Attemdance.Infrastructure.EventBus.Options;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Attemdance.Infrastructure.EventBus.Receiver
{
    public class TicketCreateReceiver : BackgroundService
    {
        private readonly ITicketService _ticketService;

        private readonly string _hostname;
        private readonly string _queueName;
        private readonly string _username;
        private readonly string _password;

        private IModel _channel;
        private IConnection _connection;

        public TicketCreateReceiver(ITicketService ticketService, 
            IOptions<RabbitMqConfiguration> rabbitMqOptions)
        {
            _ticketService = ticketService;

            _hostname = rabbitMqOptions.Value.Hostname;
            _queueName = rabbitMqOptions.Value.QueueName;
            _username = rabbitMqOptions.Value.UserName;
            _password = rabbitMqOptions.Value.Password;

            InitializeRabbitMqListener();
        }

        private void InitializeRabbitMqListener()
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password
            };

            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
            }
            catch (Exception ex)
            {
                throw new Exception("Error When Trying to Start EventBus", ex);                
            }            
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var ticket = JsonConvert.DeserializeObject<Ticket>(message);

                    HandlerTicketMessageAsync(ticket);

                    _channel.BasicAck(ea.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    _channel.BasicNack(ea.DeliveryTag, false, true);

                    throw new Exception("Error When Trying to Consume Queue", ex);
                }                
            };

            _channel.BasicConsume(_queueName, false, consumer);

            return Task.CompletedTask;
        }

        private async void HandlerTicketMessageAsync(Ticket ticket)
        {
            await _ticketService.InsertAsync(ticket);
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();

            base.Dispose();
        }
    }
}
