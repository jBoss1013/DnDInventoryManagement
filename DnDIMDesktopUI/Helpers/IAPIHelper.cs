using DnDIMDesktopUI.Models;
using System.Threading.Tasks;

namespace DnDIMDesktopUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string userName, string password);
    }
}