using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ConsoleApp.Services;

public class ContactService : IContactService

{
    private readonly IFileService _fileService = new FileService();
    private readonly string _filepath = @"c:/education/C-Sharp/ConsoleAppAssignment/contacts.json";
    private List<IContact> _contacts = [];

    public bool AddContact(IContact contact)
    {
        try
        {
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Add(contact);

                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All});

                var result =_fileService.SaveContentToFile(_filepath, json);
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }


    public IEnumerable<IContact> GetListOfContacts()
    {
        try
        {
            var content = _fileService.GetContentFromFile(_filepath);
            if (!string.IsNullOrEmpty(content))
            {
                _contacts = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return _contacts;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }


    public IContact GetDetailsOfContact(string email)
    {
        try
        {
            GetListOfContacts();
            var contact = _contacts.FirstOrDefault(x => x.Email == email);
            return contact ??= null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public bool DeleteContact(string email)
    {
        try
        {
            GetListOfContacts();
            var contact = _contacts.FirstOrDefault(x => x.Email == email);

            if (_contacts.Any(x => x.Email == contact!.Email))
            {
                _contacts.Remove(contact!);

                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                _fileService.SaveContentToFile(_filepath, json);
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

}


