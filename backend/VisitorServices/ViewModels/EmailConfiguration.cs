using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VisitorServices.ViewModels
{
    public class EmailConfiguration
    {
        [JsonPropertyName("Sender")]
        public string Sender { get; set; }
        [JsonPropertyName("SmtpServer")]
        public string SmtpServer { get; set; }
        [JsonPropertyName("Port")]
        public string Port { get; set; }
        [JsonPropertyName("Username")]
        public string Username { get; set; }
        [JsonPropertyName("Password")]
        public string Password { get; set; }



    }
}
