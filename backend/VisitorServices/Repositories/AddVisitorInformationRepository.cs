using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using VisitorServices.Entities;
using VisitorServices.ViewModels;

namespace VisitorServices.Repositories
{
    // public class AddVisitorInformationRepository : IAddVisitorInformationRepository
    // {
    //     public VisitorInformation AddVisitorInformation(VisitorInformationViewModel visitorInformation)
    //     {
    //         var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "NationalIdImages");
    //
    //         if (visitorInformation.Image.Length > 0)
    //         {
    //             var fileName = visitorInformation.Image.FileName;
    //             var fullPath = Path.Combine(pathToSave, fileName);
    //
    //             using (var stream = new FileStream(fullPath, FileMode.Create))
    //             {
    //                 visitorInformation.Image.CopyTo(stream);
    //             }
    //
    //         }
    //
    //
    //
    //
    //     }
    // }
}
