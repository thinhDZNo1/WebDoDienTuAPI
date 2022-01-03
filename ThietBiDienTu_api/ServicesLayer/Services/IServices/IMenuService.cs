using DTOlayer.Collections.Menu;
using System.Collections.Generic;

namespace ServicesLayer.Services.IServices
{
    public interface IMenuService
    {
        List<MenuToGet> GetAll();
        MenuToGet GetMenu(int id);
        void InsertMenu(MenuToAdd menu);
        void UpdateMenu(MenuToUpdate menu);
        void DeleteMenu(int id);
    }
}
