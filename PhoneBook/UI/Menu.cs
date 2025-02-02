using PhoneBook.utilities;

namespace PhoneBook.UI;

public static class Menu
{
    public static void Show()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Phone Book");
            Console.WriteLine("==========");
            Console.WriteLine("1. View Contacts");
            Console.WriteLine("2. Add contact");
            Console.WriteLine("3. Search contact");
            Console.WriteLine("4. Exit");

            var choice = MenuHelper.GetChoice();
            switch (choice)
            {
                case 1:
                    DatabaseManager.ViewContacts();
                    MenuHelper.Pause();
                    break;
                case 2:
                    DatabaseManager.AddContact();
                    MenuHelper.Pause();
                    break;
                case 3:
                    DatabaseManager.SearchContact();
                    MenuHelper.Pause();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    MenuHelper.Pause();
                    break;
            }
        }
    }
}
