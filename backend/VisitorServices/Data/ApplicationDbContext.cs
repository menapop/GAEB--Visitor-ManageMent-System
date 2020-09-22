using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VisitorServices.Entities;

namespace VisitorServices.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }




        public DbSet<VisitorInformation> VisitorInformations { get; set; }
        public DbSet<BindUser> BindUsers { get; set; }
    }
}
