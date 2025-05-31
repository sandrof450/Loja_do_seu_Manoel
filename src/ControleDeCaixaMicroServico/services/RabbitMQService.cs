using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace Teste_Loja_do_seu_emanoel.services
{
    public class RabbitMQService : IDisposable
    {
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly IConfiguration _configuration;

    public RabbitMQService(IConfiguration configuration)
    {
        _configuration = configuration;
        
        var factory = new ConnectionFactory()
        {
            HostName = _configuration["RabbitMQ:HostName"],
            UserName = _configuration["RabbitMQ:UserName"],
            Password = _configuration["RabbitMQ:Password"]
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    // Adicione métodos para publicar/consumir mensagens...
    
    public void Dispose()
    {
        _channel?.Close();
        _connection?.Close();
    }
    }
}