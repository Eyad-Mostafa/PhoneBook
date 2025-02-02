using PhoneBook.Enums;

namespace PhoneBook.Entities;

public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public ContactCategory Category { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Category: {Category}\nEmail: {Email}, Phone Number: {PhoneNumber}\n----------------------------------------------------------\n";
    }
}

