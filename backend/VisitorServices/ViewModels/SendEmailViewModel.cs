using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorServices.ViewModels
{
    public class SendEmailViewModel
    {
        public int empId { get; set; }
        public string body { get; set; }
        public string subject { get; set; }

        public int visitorId { get; set; }

       
    }
}
