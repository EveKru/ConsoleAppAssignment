using ConsoleApp.Interfaces;
using ConsoleApp.Models;

namespace ConsoleApp.Services;

internal class MenuService : IMenuService
{

    private readonly IContactService _contactservice = new ContactService();

    public void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("## MENU OPTIONS ##");
            Console.WriteLine();

            Console.WriteLine($"{"1.",-2} Add New Contact");
            Console.WriteLine($"{"2.",-2} View All Contacts");
            Console.WriteLine($"{"3.",-2} Show Contact Details");
            Console.WriteLine($"{"4.",-2} DELETE Contact");
            Console.WriteLine($"{"5.",-2} EXIT");

            Console.WriteLine();
            Console.Write("Enter Option: ");
            var option = Console.ReadLine();

            switch(option)
            {
                case "1":
                    ShowAddContact();
                break;

                case "2":
                    ShowAllContacts();
                break;

                case "3":
                    ShowContactDetails();
                break;

                case "4":
                    ShowDeleteContact();
                break;

                case "5":
                    ShowExitApplication();
                break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid Option. Press Any Key To Try Again.");
                    Console.ReadKey();
                break;
            }
        }
    }

    public void ShowAddContact()
    {
        IContact contact = new Contact();

        Console.Clear();
        Console.WriteLine("Add New Contact");
        Console.WriteLine();

        Console.Write("First Name: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("Last Name: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write("Email: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("Adress: ");
        contact.Adress = Console.ReadLine()!;

        Console.Write("Phone Number: ");
        contact.PhoneNumber = Console.ReadLine()!;

        var result = _contactservice.AddContact(contact);
        Console.WriteLine();

        if (result)
        {
            Console.WriteLine("Contact successfully added.");
        }
        else
        { 
            Console.WriteLine("Unable to add contact."); 
        }

        Console.ReadKey();
    }

    public void ShowAllContacts()

    {
        Console.Clear();
        var contacts = _contactservice.GetListOfContacts();
        foreach (var contact in contacts)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"{contact.FirstName} {contact.LastName}");
            Console.WriteLine($"{contact.Email}");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine();
        }
        Console.ReadKey();

    }

    public void ShowContactDetails()
    {
        Console.Clear();

        Console.WriteLine("Type in the email of the contact to access more details:");
        var email = Console.ReadLine()!;
        var contact = _contactservice.GetDetailsOfContact(email);

        Console.WriteLine();
        Console.WriteLine("ALL CUSTOMER DETAILS:");
        Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
        Console.WriteLine($"Email: {contact.Email}");
        Console.WriteLine($"Adress: {contact.Adress}");
        Console.WriteLine($"ID: {contact.Id}");

        Console.ReadKey();
        
    }

    public void ShowDeleteContact()
    {
        Console.Clear();

        Console.WriteLine("Type in the email of the contact to DELETE all saved data.");
        Console.WriteLine();
        var email = Console.ReadLine()!;
        var contact =  _contactservice.DeleteContact(email);

        if (contact == true)
        {
            Console.WriteLine($"User with the email ( {email} ) successfully deleted.");
        }
        if (contact == false) 
        {
            Console.WriteLine($"Unable to delete contact with email : {email}");
        }

        Console.ReadKey();

    }

    public void ShowExitApplication()
    {
        Console.Clear();
        Console.Write("Are You Sure You Want To Exit? (y/n): ");
        var option = Console.ReadLine() ?? "";

        if (option.ToLower() == "y")
            Environment.Exit(0);
    }
}
