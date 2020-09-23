using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorServices.Entities;

namespace VisitorServices.ViewModels
{
    public class TokenAndMessageReturn
    {
        public string Token { get; set; }
        public string Message { get; set; }
        public VisitorInformationForReturn VisitorInformationForReturn { get; set; }
        public int StatusCode { get; set; }
    }
}
