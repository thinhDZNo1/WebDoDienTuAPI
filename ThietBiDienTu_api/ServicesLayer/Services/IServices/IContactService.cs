using DTOlayer.Collections.Contact;
using System.Collections.Generic;

namespace ServicesLayer.Services.IServices
{
    public interface IContactService
    {
        List<ContactToGet> GetAll();
        ContactToGet GetContact(int id);
        void InsertContact(ContactToAdd contact);
        void UpdateContact(ContactToUpdate contact);
        void DeleteContact(int id);
    }
}
