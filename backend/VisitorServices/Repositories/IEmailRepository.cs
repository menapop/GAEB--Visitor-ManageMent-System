using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VisitorServices.Repositories
{
   public  interface IEmailRepository
    {
        bool SendEmail(string To, String Messagebody);
    }
}
