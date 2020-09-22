using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Internal;

namespace VisitorServices.Entities
{

    public class VisitorInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Governrate { get; set; }
        public string Address { get; set; }
        public BindUser BindUser { get; set; }
        public string Image { get; set; }

    }
}
