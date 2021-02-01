using DnDIMDesktopUI.Library.Model;
using System.Threading.Tasks;

namespace DnDIMDesktopUI.Helpers.API
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string userName, string password);
        Task GetLoggedInUserInfo(string token);
    }
}