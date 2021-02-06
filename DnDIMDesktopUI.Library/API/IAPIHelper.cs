using DnDIMDesktopUI.Library.Model;
using System.Net.Http;
using System.Threading.Tasks;

namespace DnDIMDesktopUI.Helpers.API
{
    public interface IAPIHelper
    {
        HttpClient ApiClient { get; }
        Task<AuthenticatedUser> Authenticate(string userName, string password);
        Task GetLoggedInUserInfo(string token);
    }
}