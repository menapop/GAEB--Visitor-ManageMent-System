using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using VisitorServices.Data;
using VisitorServices.Entities;
using VisitorServices.ViewModels;

namespace VisitorServices.Repositories
{
    public class AddVisitorInformationRepository : IAddVisitorInformationRepository
    {
        private readonly ApplicationDbContext _db;

        public AddVisitorInformationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public VisitorInformationViewModel AddVisitorInformation(VisitorInformationViewModel visitorInformationViewModel)
        {
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/NationalIdImages");
            var fileName = string.Empty;

            if (visitorInformationViewModel.Image != null)
            {
                fileName = visitorInformationViewModel.Image.FileName;
                var fullPath = Path.Combine(pathToSave, fileName);
    
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    visitorInformationViewModel.Image.CopyTo(stream);
                }
    
            }

            var visitorInformation = new VisitorInformation
            {
                Name = visitorInformationViewModel.Name,
                Address = visitorInformationViewModel.Address,
                Email = visitorInformationViewModel.Email,
                Governrate = visitorInformationViewModel.Governrate,
                IdNumber = visitorInformationViewModel.IdNumber,
                Phone = visitorInformationViewModel.Phone,
                Image = fileName
            };

            _db.VisitorInformations.Add(visitorInformation);
            _db.SaveChanges();

            return visitorInformationViewModel;

        }
    }
}
