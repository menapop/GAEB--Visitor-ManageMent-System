using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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
           // mailconfig= _configuration.GetSection
        }
        public bool SendEmail(string To, string Messagebody)
        {
            throw new NotImplementedException();
        }
    }
}
