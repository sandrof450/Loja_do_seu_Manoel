using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ControleDeCaixaMicroServico.Models;

public class RabbitMQConfig
{
    [Required]
    public string HostName { get; set; } = string.Empty;
    
    [Required]
    public string UserName { get; set; } = string.Empty;
    
    [Required]
    public string Password { get; set; } = string.Empty;
    
    [Required]
    public string QueueName { get; set; } = string.Empty;
}