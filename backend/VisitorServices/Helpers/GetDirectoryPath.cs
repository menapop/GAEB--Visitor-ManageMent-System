using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;

namespace VisitorServices.Helpers
{
    public static class GetDirectoryPath
    {
        public static string GetImagePath(HttpRequest request, string image)
        {
            var baseUrl = request.GetDisplayUrl().Split("api")[0];


            return image != null ? $"{baseUrl}wwwroot/NationalIdImages/{image}" : "";
        }
    }
}
