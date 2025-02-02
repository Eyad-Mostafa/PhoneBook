using PhoneBook.Entities;
using PhoneBook.Enums;
using System.Text.RegularExpressions;

namespace PhoneBook.Utilities;

public static class DatabaseHelper
{
    public static Contact? GetContact()
    {
        var contact = new Contact();
        Console.Clear();

        Console.Write("Enter name (or 0 to go back): ");
        string nameInput = Console.ReadLine().Trim();
        if (nameInput == "0") return null;
        if (string.IsNullOrEmpty(nameInput))
        {
            Console.WriteLine("Name is required.");
            return GetContact();
        }
        contact.Name = nameInput;

        Console.Write("Enter email (e.g., name@example.com) or 0 to go back: ");
        string emailInput = Console.ReadLine().Trim();
        if (emailInput == "0") return null;

        while (!IsValidEmail(emailInput))
        {
            Console.WriteLine("Invalid email format. Try again (e.g., name@example.com).");
            Console.Write("Enter email: ");
            emailInput = Console.ReadLine().Trim();
            if (emailInput == "0") return null;
        }
        contact.Email = emailInput;

        Console.Write("Enter phone (e.g., +201234567890) or 0 to go back: ");
        string phoneInput = Console.ReadLine().Trim();
        if (phoneInput == "0") return null;

        while (!IsValidPhone(phoneInput))
        {
            Console.WriteLine("Invalid phone format. Try again (e.g., +201234567890).");
            Console.Write("Enter phone: ");
            phoneInput = Console.ReadLine().Trim();
            if (phoneInput == "0") return null;
        }
        contact.PhoneNumber = phoneInput;

        Console.WriteLine("Choose a category:");
        foreach (var category in Enum.GetNames(typeof(ContactCategory)))
        {
            Console.WriteLine($"- {category}");
        }

        Console.Write("Enter category or 0 to go back: ");
        while (true)
        {
            string input = Console.ReadLine().Trim().ToLower();
            if (input == "0") return null;

            if (Enum.TryParse(typeof(ContactCategory), input, true, result: out var category))
            {
                contact.Category = (ContactCategory)category;
                break;
            }

            Console.WriteLine("Invalid category. Please enter a valid option.");
        }

        return contact;
    }

    public static bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    public static bool IsValidPhone(string phone)
    {
        return Regex.IsMatch(phone, @"^(?:\+20)?(10|11|12)\d{8}$");
    }
}
