using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhoneBook.Entities;
using PhoneBook.Enums;
using PhoneBook.Utilities;

namespace PhoneBook.utilities;

public static class DatabaseManager
{
    public static void ViewContacts()
    {
        Console.Clear();
        Console.WriteLine("Contacts:\n");

        using (var context = new AppDbContext())
        {
            context.Contacts.ToList().ForEach(c => Console.WriteLine(c));
            if (!context.Contacts.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No contacts found.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    public static void AddContact()
    {
        var contact = DatabaseHelper.GetContact();

        if (contact == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Contact not added.");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        using (var context = new AppDbContext())
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Contact Added successfully");
        Console.ForegroundColor = ConsoleColor.White;
    }

    internal static void SearchContact()
    {
        Console.Clear();
        Console.Write("Please Enter contact name (0 to back): ");
        string? contactName = Console.ReadLine()?.Trim();


        while (true)
        {
            if (contactName == "0") return;

            if (string.IsNullOrEmpty(contactName))
            {
                Console.WriteLine("Please Enter a valid Name");
                continue;
            }

            using (var context = new AppDbContext())
            {
                var contacts = context.Contacts;
                var contact = contacts
                    .FirstOrDefault(
                        c => c.Name.ToLower() == contactName.ToLower()
                    );

                if (contact == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Contact Not Fount");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                Console.Clear();
                Console.WriteLine(contact);
                Console.WriteLine("-----------------");
                Console.WriteLine("1. Edit Contact");
                Console.WriteLine("2. Delete Contact");
                Console.WriteLine("3. Back");

                var choice = MenuHelper.GetChoice();

                switch (choice)
                {
                    case 1:
                        EditContact(contact);
                        return;
                    case 2:
                        DeleteContact(contact);
                        return;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        return;
                }
            }
        }
    }

    private static void EditContact(Contact contact)
    {
        if (contact == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid contact.");
            Console.ResetColor();
            return;
        }

        Console.Clear();
        Console.WriteLine("Editing Contact:");

        using (var context = new AppDbContext())
        {
            var editedContact = context.Contacts
                .AsTracking()
                .FirstOrDefault(c => c.Id == contact.Id);

            Console.WriteLine($"Current Name: {editedContact.Name}");
            Console.Write("Enter new name (or press Enter to keep current): ");
            string nameInput = Console.ReadLine().Trim();

            if (!string.IsNullOrEmpty(nameInput))
                editedContact.Name = nameInput;

            Console.WriteLine($"Current Email: {editedContact.Email}");
            Console.Write("Enter new email (or press Enter to keep current): ");
            string emailInput = Console.ReadLine().Trim();

            if (!string.IsNullOrEmpty(emailInput))
            {
                while (!DatabaseHelper.IsValidEmail(emailInput))
                {
                    Console.WriteLine("Invalid email format. Try again (e.g., name@example.com).");
                    Console.Write("Enter new email: ");
                    emailInput = Console.ReadLine().Trim();
                }
                editedContact.Email = emailInput;
            }

            Console.WriteLine($"Current Phone: {editedContact.PhoneNumber}");
            Console.Write("Enter new phone (or press Enter to keep current): ");
            string phoneInput = Console.ReadLine().Trim();

            if (!string.IsNullOrEmpty(phoneInput))
            {
                while (!DatabaseHelper.IsValidPhone(phoneInput))
                {
                    Console.WriteLine("Invalid phone format. Try again (e.g., +201234567890).");
                    Console.Write("Enter new phone: ");
                    phoneInput = Console.ReadLine().Trim();
                }
                editedContact.PhoneNumber = phoneInput;
            }

            Console.WriteLine($"Current Category: {editedContact.Category}");
            Console.WriteLine("Choose a new category (or press Enter to keep current):");

            foreach (var category in Enum.GetNames(typeof(ContactCategory)))
            {
                Console.WriteLine($"- {category.ToLower()}");
            }

            while (true)
            {
                string input = Console.ReadLine().Trim().ToLower();

                if (string.IsNullOrEmpty(input))
                    break;

                if (Enum.TryParse(typeof(ContactCategory), input, true, out object category))
                {
                    editedContact.Category = (ContactCategory)category;
                    break;
                }

                Console.WriteLine("Invalid category. Please enter a valid option.");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Contact updated successfully!");
            Console.ResetColor();
            context.SaveChanges();
        }
    }

    private static void DeleteContact(Contact contact)
    {
        using (var context = new AppDbContext())
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();
        }
    }
}
