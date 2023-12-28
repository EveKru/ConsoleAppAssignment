namespace ConsoleApp.Interfaces;

public interface IMenuService

{
    /// <summary>
    /// shows the main menu with all options
    /// </summary>
    void ShowMenu();

    /// <summary>
    /// shows all exisiting contacts
    /// </summary>
    void ShowAllContacts();

    /// <summary>
    /// shows specified details of a contact
    /// </summary>
    void ShowContactDetails();

    /// <summary>
    /// shows the menu for adding the contact
    /// </summary>
    void ShowAddContact();

    /// <summary>
    /// shows the menu for deleting a contact
    /// </summary>
    void ShowDeleteContact();

    /// <summary>
    /// shows the "yes or no" option before exiting the application
    /// </summary>
    void ShowExitApplication();
}
