using Business.Factories;
using Business.Models;
namespace Business.Services;

public class MenuDialogs
{
    private readonly UserService _userService = new UserService();  

    public void Show ()
    {       
            while (true)
        {
            ShowMainMenu();
        }
    }    
    public void ShowMainMenu()
    {
        Console.Clear();
        Console.WriteLine("\n--- The List ---");
        Console.WriteLine($"{"1.",-5} List all users");
        Console.WriteLine($"{"2.",-5} Add new user");
        Console.WriteLine($"{"Q.",-5} Quit");
        Console.Write("Choose an option: ");
        var option = Console.ReadLine()!;

        switch (option)
        {
            case "1":
                ListOption();
                break;
            case "2":
                CreateOption();
                break;
            case "q":
                QuitOption();
                break;
            default:
                InvalidOption();
                break;
        }        
    }
    public void ListOption()
    {
        
        var users = _userService.GetAll();
        Console.Clear();

        foreach (var user in users)
        {
            Console.WriteLine($"{"Id:", -5} {user.Id}");
            Console.WriteLine($"{"First Name:", -5} {user.FirstName}");
            Console.WriteLine($"{"Last Name:", -5} {user.LastName}");
            Console.WriteLine($"{"Email:", -5} {user.Email}");
            Console.WriteLine($"{"Phone Number:", -5} {user.PhoneNumber}");
            Console.WriteLine($"{"Address:", -5} {user.Address}");
            Console.WriteLine($"{"Zip Code:", -5} {user.ZipCode}");
            Console.WriteLine($"{"County:", -5} {user.County}");
            Console.WriteLine("");
        }
        Console.ReadKey();
    }

    public void CreateOption()
    {
        UserRegistrationForm userRegistrationForm = UserFactory.Create();

        Console.Clear();

        Console.Write("Enter your first name: ");
        userRegistrationForm.FirstName = Console.ReadLine()!;

        Console.Write("Enter your last name: ");
        userRegistrationForm.LastName = Console.ReadLine()!;

        Console.Write("Enter your email: ");
        userRegistrationForm.Email = Console.ReadLine()!;

        Console.Write("Enter your phonenumber: ");
        userRegistrationForm.PhoneNumber = Console.ReadLine()!;

        Console.Write("Enter your address: ");
        userRegistrationForm.Address = Console.ReadLine()!;

        Console.Write("Enter your zipcode: ");
        userRegistrationForm.ZipCode = Console.ReadLine()!;

        Console.Write("Enter your county: ");
        userRegistrationForm.County = Console.ReadLine()!;

        bool result = _userService.Create(userRegistrationForm);   
        
        if (result)        
            OutputDialog("\nUser added successfully.");
        else
            OutputDialog("\nUser was not created try again.");


    }
    public void QuitOption()
    {
        Console.Clear();
        Console.WriteLine("Do you want to quit this application? (y/n):");
        var option = Console.ReadLine()!;

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);
        }
    }
    public  void InvalidOption()
    {
        Console.Clear();
        Console.WriteLine("\nInvalid choice, try again");
        Console.ReadKey();
    }
    public void OutputDialog(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Console.ReadKey();
    }
}
