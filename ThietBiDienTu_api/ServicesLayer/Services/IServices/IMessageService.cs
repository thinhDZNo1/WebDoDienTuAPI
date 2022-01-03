using DTOlayer.Collections.Message;
using System.Collections.Generic;

namespace ServicesLayer.Services.IServices
{
    public interface IMessageService
    {
        List<MessageToGet> GetAll();
        MessageToGet GetMessage(int id);
        void InsertMessage(MessageToAdd message);
        void UpdateMessage(MessageToUpdate message);
        void DeleteMessage(int id);
    }
}
