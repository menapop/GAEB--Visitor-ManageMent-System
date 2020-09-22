using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorServices.Entities;

namespace VisitorServices.ViewModels
{
    public class VisitorInformationForReturnStatus
    {
        public VisitorInformation VisitorInformation { get; set; }
        public string Status { get; set; }
    }
}
