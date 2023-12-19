using ConsoleApp.Models;

namespace ConsoleApp.Interfaces;

public interface IContactService
{
    bool AddContact(IContact contact);

    IEnumerable<IContact> GetListOfContacts();

    IContact GetDetailsOfContact(string email);

    bool DeleteContact(string email);

}
