using ConsoleApp.Models;

namespace ConsoleApp.Interfaces;

public interface IContactService
{
    /// <summary>
    /// Adds a contact to the list 
    /// </summary>
    /// <param name="contact"></param>
    /// <returns>returns true if no email of the same kind exists, else returns false</returns>
    bool AddContact(IContact contact);

    /// <summary>
    /// Gets the list of contacts
    /// </summary>
    /// <returns>returns the list of contacts, else null if empty </returns>
    IEnumerable<IContact> GetListOfContacts();

    /// <summary>
    /// Gets details of a specified contact
    /// </summary>
    /// <param name="email"></param>
    /// <returns>returns contact, else returns null if contacts does not exist</returns>
    IContact GetDetailsOfContact(string email);

    /// <summary>
    /// Removes a specified contact from the list of contacts
    /// </summary>
    /// <param name="email"></param>
    /// <returns>returns true if contact successfully deleted, else false</returns>
    bool DeleteContact(string email);

}
