using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;
using VisitorServices.ViewModels;

namespace VisitorServices.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly EmailConfiguration mailconfig;
        private readonly IConfiguration _configuration;
        public EmailRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            mailconfig = _configuration.GetSection("MailConfiguration").Get<EmailConfiguration>();
        }
        public bool SendEmail(SendEmailViewModel email)
        {
            MimeMessage message = new MimeMessage();
            MailboxAddress from = new MailboxAddress("Admin",
           mailconfig.Sender);
            message.From.Add(from);
            MailboxAddress to = new MailboxAddress("User",
            email.ToEmail);
            message.To.Add(to);
            message.Subject = email.mailsubject;

            BodyBuilder bodyBuilder = new BodyBuilder();
           
            bodyBuilder.TextBody = email.mailbody;

            message.Body = bodyBuilder.ToMessageBody();


            SmtpClient client = new SmtpClient();


            client.Connect(mailconfig.SmtpServer, mailconfig.Port, false);

            client.Authenticate(mailconfig.Username, mailconfig.Password);

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
            return true;
        }

       
    }
}
