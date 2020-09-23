using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using VisitorServices.Entities;
using VisitorServices.ViewModels;

namespace VisitorServices.Repositories
{
    public interface IAddVisitorInformationRepository
    {
        VisitorInformation AddVisitorInformation(VisitorInformationForCreation visitorInformationViewModel);
    }
}
