using DTOlayer.Collections.ConfirmOrder;
using System.Collections.Generic;

namespace ServicesLayer.Services.IServices
{
    public interface IConfirmOrderService
    {
        List<ConfirmOrderToGet> GetAll();
        ConfirmOrderToGet GetConfirmOrder(int id);
        void InsertConfirmOrder(ConfirmOrderToAdd confirmOrder);
        void UpdateConfirmOrder(ConfirmOrderToUpdate confirmOrder);
        void DeleteConfirmOrder(int id);
    }
}
