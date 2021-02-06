using DnDIMDesktopUI.Library.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnDIMDesktopUI.Library.API
{
    public interface IItemEndPoint
    {
        Task<List<ItemsModel>> GetAll();
    }
}