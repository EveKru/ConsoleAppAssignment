
using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using ConsoleApp.Services;
using System.ComponentModel.DataAnnotations;

namespace ContactBook.Tests;

public class ContactService_Test
{
    [Fact]
    public void AddContactShould_AddOneContactToList_ThenReturnTrue()
    {

        // Arrange 
        IContact contact = new Contact { FirstName = "Test", LastName = "Test", Email = "test.test@test.com", Adress = "test", PhoneNumber = "123456789" };
        IContactService contactservice = new ContactService();

        // Act 
        var result = contactservice.AddContact(contact);

        // Assert
        Assert.True(result);

    }

    [Fact]
    public void GetListOfContactsShould_GetAllContactsFromList_ThenReturnListOfContacts()
    {

        // Arrange 
        IContactService contactservice = new ContactService();
        IContact contact = new Contact { FirstName = "Test", LastName = "Test", Email = "test.test@test.com", Adress = "test", PhoneNumber = "123456789"};
        contactservice.AddContact(contact);

        // Act 
        var result = contactservice.GetListOfContacts();
       
        // Assert
        Assert.NotNull(result);
        Assert.True(result.Any());

    }

    [Fact]
    public void GetDetailsOfContactShould_GetContactFromList_ThenReturnDetailsOfContact()
    {

        // Arrange 
        IContactService contactservice = new ContactService();
        IContact contact = new Contact { FirstName = "Test", LastName = "Test", Email = "test.test@test.com", Adress = "test", PhoneNumber = "123456789" };
        contactservice.AddContact(contact);
        string email = "test.test@test.com";

        // Act 

        var result = contactservice.GetDetailsOfContact(email);

        // Assert
        Assert.NotNull(result);

    }

    [Fact]
    public void DeleteContactShould_RemoveContactFromList_ThenReturnTrue()
    {
        // Arrange
        IContactService contactservice = new ContactService();
        IContact contact = new Contact { FirstName = "Test", LastName = "Test", Email = "test.test@test.com", Adress = "test", PhoneNumber = "123456789" };
        contactservice.AddContact(contact);
        string email = "test.test@test.com";

        // Act

        bool result = contactservice.DeleteContact(email);

        // Assert
        Assert.True(result);
    }

}


