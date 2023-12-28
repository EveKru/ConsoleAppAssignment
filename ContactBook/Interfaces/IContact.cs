namespace ConsoleApp.Interfaces;

public interface IContact
{
    string Email { get; set; }
    string FirstName { get; set; }
    Guid Id { get; set; } 
    string LastName { get; set; }
    string PhoneNumber { get; set; }
    string Adress { get; set; }
}