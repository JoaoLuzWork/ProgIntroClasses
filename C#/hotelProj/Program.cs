
class Program
{
    public static void DisplayMenu()
    {
        Console.WriteLine("\n=========== Welcome to Hotel Silverstone! ===========\n");
        Console.WriteLine("if you are a new user, please register first!");
        Console.WriteLine("1.Registration");
        Console.WriteLine("2.Login");
        Console.WriteLine("3.Exit");
        Console.WriteLine("Please select an option:");
    }
    public static List<User> users = new List<User>();
    public static List<Admin> admins = new List<Admin>();
    public static List<Room> rooms = new List<Room>();
    public static List<Bookings> bookings = new List<Bookings>();
    public static Admin currentAdmin = null;
    public static User currentUser = null;

    public static void registeraUser()
    {
        Console.WriteLine("Enter your first name: ");
        string firstName = Console.ReadLine();

        Console.WriteLine("Enter your last name: ");
        string lastName = Console.ReadLine();

        Console.WriteLine("Enter your email: ");
        string email = Console.ReadLine();

        Console.WriteLine("Enter your phone number: ");
        string phoneNumber = Console.ReadLine();

        Console.WriteLine("Enter your password: ");
        string password = Console.ReadLine(); // Default password for simplicity

        users.Add(new User(User.userIdCounter, firstName, lastName, email, password, phoneNumber));
        User.userIdCounter++;
        User currentUser = users[users.Count - 1]; // Set the current user to the newly registered user
        Console.WriteLine($"Welcome, {currentUser.FirstName} {currentUser.LastName}! You have registered successfully.");
        users[users.Count - 1].DisplayUserMenu();

    }

    static void Main()
    {
        //pre defined admin user
        admins.Add(new Admin(0, "Joao", "Rodrigues", "joao@gmail.com", "1234", "123-456-7890")); // Predefined admin user

        //pre defined rooms
        rooms.Add(new Room(0, "101", "Single", 100.00m, true));
        rooms.Add(new Room(1, "102", "Double", 150.00m, true));
        rooms.Add(new Room(2, "103", "Suite", 250.00m, false));

        int loginAttempts = 0; // Track login attempts

        void login()
        {
            Console.WriteLine("Enter your email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();

            Admin matchedAdmin = admins.Find(a => a.Email == email && a.Password == password);
            User matchedUser = users.Find(u => u.Email == email && u.Password == password);
            if (matchedAdmin != null)
            {
                Console.WriteLine("Admin login successful!\n");
                matchedAdmin.DisplayAdminMenu();//goes to the admin menu
                }
                else if (matchedUser != null)
                {
                    Console.WriteLine("User login successful!\n");
                    matchedUser.DisplayUserMenu();//goes to the user menu
                    }
                    else
                    {
                        Console.WriteLine("Invalid email or password. Please try again.\n");
                        loginAttempts++; // Increment the login attempts counter
                        if (loginAttempts >= 3) // Check if the user has exceeded the maximum allowed attempts
                        {
                            Console.WriteLine("Too many failed login attempts. Please try again later.\n");
                            loginAttempts = 0; // Reset the counter
                            DisplayMenu(); //goes back to the main menu
                        }
                        else
                        {
                            login(); //try to login again
                        }
                    }
        }

        DisplayMenu();
        while (true)
        {
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    registeraUser();
                    break;
                case 2:
                    login();//call the login function
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}