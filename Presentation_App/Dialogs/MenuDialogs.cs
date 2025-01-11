using Business.Factories;
using Business.Interfaces;
namespace Presentation_App.Dialogs;

public class MenuDialogs(IUserService userService)
{
    private readonly IUserService _userService = userService;

    public void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n--- The List ---");
            Console.WriteLine($"{"1.",-5} Add new user");
            Console.WriteLine($"{"2.",-5} List all users");
            Console.WriteLine($"{"Q.",-5} Quit");
            Console.Write("Choose an option: ");
            var option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    AddUser();
                    break;
                case "2":
                    ListOption();
                    break;
                case "q":
                    QuitOption();
                    break;

            }
        }
     }
       public void AddUser()
    {
        var form = UserFactory.Create();

        Console.Clear();
        Console.WriteLine("\n--- Add new user ---");
        Console.Write("First name:");
        form.FirstName = Console.ReadLine()!;
        Console.Write("Last name:");
        form.LastName = Console.ReadLine()!;
        Console.Write("Email:");
        form.Email = Console.ReadLine()!;
        Console.Write("Phone number:");
        form.PhoneNumber = Console.ReadLine()!;
        Console.Write("Address:");
        form.Address = Console.ReadLine()!;
        Console.Write("Zip Code:");
        form.ZipCode = Console.ReadLine()!;
        Console.Write("County:");
        form.County = Console.ReadLine()!;
        Console.WriteLine();

        var result = _userService.Save(form);
        if (result)
        {
            Console.WriteLine("User added successfully!");
        }
        else
        {
            Console.WriteLine("Failed to add user!");
        }
        Console.ReadKey();
    }
    public void ListOption()
    {
        Console.Clear();
        Console.WriteLine("\n--- View all Users ---");
        var users = _userService.GetAll();
        foreach (var user in users)
        {
            Console.WriteLine($"{"Id:",-5} {user.Id}");
            Console.WriteLine($"{"First Name:",-5} {user.FirstName}");
            Console.WriteLine($"{"Last Name:",-5} {user.LastName}");
            Console.WriteLine($"{"Email:",-5} {user.Email}");
            Console.WriteLine($"{"Phone Number:",-5} {user.PhoneNumber}");
            Console.WriteLine($"{"Address:",-5} {user.Address}");
            Console.WriteLine($"{"Zip Code:",-5} {user.ZipCode}");
            Console.WriteLine($"{"County:",-5} {user.County}");
            Console.WriteLine("");
        }
        Console.ReadKey();
    }
    public void QuitOption()
    {

    }
}
