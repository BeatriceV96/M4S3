using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using Weeklyapp.DataLayer.Entities;

namespace Weeklyapp.DataLayer.Services.Interfaces
{
    public interface IAuthService
    {
        ApplicationUser Login(string username, string password);
    }
}
