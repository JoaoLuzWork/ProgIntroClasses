public class User{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }

    public static int userIdCounter = 0;

    public User(int userId, string firstName, string lastName, string email, string password, string phoneNumber)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
    }

    public static void DisplayUserMenu()
    {
        Console.WriteLine("\n=================================");
        Console.WriteLine("=========== User Menu ===========");
        Console.WriteLine("=================================\n");

        Console.WriteLine("1. View Available Rooms");
        Console.WriteLine("2. Book a Room");
        Console.WriteLine("3. View My Bookings");
        Console.WriteLine("4. Cancel Bookings");
        Console.WriteLine("5. Update Bookings");
        Console.WriteLine("6. Edit Profile");
        Console.WriteLine("7. Logout");
        Console.WriteLine("Please select an option:");

        int userOption = Convert.ToInt32(Console.ReadLine());
        switch (userOption)
        {
            case 1:
                Room.AvailableRooms();
                break;
            case 2:
                Bookings.BookRoom();
                break;
            case 3:
                Bookings.ViewMyBookings();
                break;
            case 4:
                Bookings.CancelBooking();
                break;
            case 5:
                Bookings.UpdateBooking();
                break;
            case 6:
                EditProfile();
                break;
            case 7:
                Console.WriteLine("Logging out...");
                Program.DisplayMenu(); // Return to the main menu
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                DisplayUserMenu();
                break;
        }
    }

    static void EditProfile()
    {
        Console.WriteLine("\n==================================");
        Console.WriteLine("============ Edit Profile ===========");
        Console.WriteLine("==================================");

        //get the current user from program and defines as the object of manipulation
        User user = Program.currentUser;

        Console.WriteLine($"Enter new first name (leave blank to keep '{user.FirstName}'): ");
        string firstName = Console.ReadLine();

        Console.WriteLine($"Enter new last name (leave blank to keep '{user.LastName}'): ");
        string lastName = Console.ReadLine();

        Console.WriteLine($"Enter new email (leave blank to keep '{user.Email}'): ");
        string email = Console.ReadLine();

        Console.WriteLine("Enter new password (leave blank to keep current password): ");
        string password = Console.ReadLine();

        Console.WriteLine($"Enter new phone number (leave blank to keep '{user.PhoneNumber}'): ");
        string phoneNumber = Console.ReadLine();

        //this conditional check if the variable receivide is not(!) null 
        //if it is null nothing will change, if it is not null the values will be overwrited
        if (!string.IsNullOrWhiteSpace(firstName))
            user.FirstName = firstName;

        if (!string.IsNullOrWhiteSpace(lastName))
            user.LastName = lastName;

        if (!string.IsNullOrWhiteSpace(email))
            user.Email = email;

        if (!string.IsNullOrWhiteSpace(password))
            user.Password = password;

        if (!string.IsNullOrWhiteSpace(phoneNumber))
            user.PhoneNumber = phoneNumber;

        Console.WriteLine("Profile updated successfully!");
        DisplayUserMenu(); // Return to the user menu after editing profile
    }
}