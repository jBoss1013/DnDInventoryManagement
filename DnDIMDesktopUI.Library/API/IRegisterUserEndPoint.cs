using DnDIMDesktopUI.Library.Model;
using System.Threading.Tasks;

namespace DnDIMDesktopUI.Library.API
{
   public interface IRegisterUserEndPoint
    {
        Task PostRegisterUser(RegisterUserModel user);
    }
}