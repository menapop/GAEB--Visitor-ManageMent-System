using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;
using VisitorServices.ViewModels;
using VisitorServices.Data;
using VisitorServices.Entities;

namespace VisitorServices.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly EmailConfiguration mailconfig;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;
        private readonly IEmployeeRepository _EmailRepository;
        public EmailRepository(IConfiguration configuration, ApplicationDbContext db, IEmployeeRepository EmailRepository)
        {
            _configuration = configuration;
            mailconfig = _configuration.GetSection("MailConfiguration").Get<EmailConfiguration>();
            _db = db;
            _EmailRepository = EmailRepository;
        }
        public async Task<bool> SendEmail(SendEmailViewModel email)
        {
            var EmployeeEmail =  await _EmailRepository.GetEmployeeEmailByEmployeeNumber(email.empId);

            MimeMessage message = new MimeMessage();
            MailboxAddress from = new MailboxAddress("Admin",
           mailconfig.Sender);
            message.From.Add(from);
            MailboxAddress to = new MailboxAddress("User",
           EmployeeEmail);
            message.To.Add(to);
            message.Subject = email.subject;

            BodyBuilder bodyBuilder = new BodyBuilder();
           
            bodyBuilder.TextBody = email.body;

            message.Body = bodyBuilder.ToMessageBody();


            SmtpClient client = new SmtpClient();


           await client.ConnectAsync(mailconfig.SmtpServer, mailconfig.Port, false);

            await client.AuthenticateAsync(mailconfig.Username, mailconfig.Password);

            await client.SendAsync(message);
            await client.DisconnectAsync(true);
             client.Dispose();
            var mail = new Mails
            {
                EmployeeNumber=email.empId,
                MailMessage=email.body,
                MailSubject= email.subject,
                VisitorId=email.visitorId,
                SendTime=DateTime.Now
            };

              await _db.Mails.AddAsync(mail);
             _db.SaveChanges();

            return true;
        }

       
    }
}
