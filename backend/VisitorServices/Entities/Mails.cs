using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorServices.Entities
{
    public class Mails
    {
        public int  Id  { get; set; }
        public string  MailSubject { get; set; }
        public string MailMessage{ get; set; }

        public int EmployeeNumber { get; set; }

        public int VisitorId { get; set; }

        public DateTime SendTime { get; set; } = DateTime.Now;
        [ForeignKey("VisitorId")]
        public VisitorInformation Visitor { get; set; }


    }
}
