using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorServices.Entities
{
    public class BindUser
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        [ForeignKey("VisitorInformationId")]
        public VisitorInformation VisitorInformation { get; set; }
        public int VisitorInformationId { get; set; }

    }
}
