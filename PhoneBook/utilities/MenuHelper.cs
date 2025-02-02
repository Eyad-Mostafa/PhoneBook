namespace PhoneBook.utilities;

public class MenuHelper
{
    public static int GetChoice()
    {
        if (int.TryParse(Console.ReadLine()?.Trim(), out int choice))
            return choice;
        else
            return -1;
    }

    public static void Pause()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
