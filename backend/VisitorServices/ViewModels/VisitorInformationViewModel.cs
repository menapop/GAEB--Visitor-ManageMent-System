using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace VisitorServices.ViewModels
{
    public class VisitorInformationViewModel
    {
        public string Name { get; set; }
        public string IdNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Governrate { get; set; }
        public string Address { get; set; }
        public IFormFile Image { get; set; }

    }
}
