
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

    const int MAX_USERS = 2; // Avoid Hardcode
    public static User[] users = new User[MAX_USERS];
    const int MAX_ADMINS = 2;  // Avoid Hardcode
    public static Admin[] admins = new Admin[MAX_ADMINS];
    static void Main()
    {
        
        admins[0] = new Admin(0, "Joao", "Rodrigues", "joao@gmail.com", "1234", "123-456-7890"); // Predefined admin user

        int count = 0; //add user progressively, to keep track of the number of registered users
        int loginAttempts = 0; // Track login attempts

        void login()
        {
            Console.WriteLine("Enter your email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();

            if (email == admins[0].Email && password == admins[0].Password) // Check if the admin credentials match
            {
                Console.WriteLine("Admin login successful!\n");
                admins[0].DisplayAdminMenu();
            }
            else
            {
                bool userFound = false;
                for (int i = 0; i < count; i++)
                {
                    if (users[i] != null && users[i].Email == email && users[i].Password == password) // Check if the user exists and the password matches
                    {
                        Console.WriteLine("User login successful!\n");
                        users[i].DisplayUserMenu();//goes to the user menu
                        userFound = true;
                        break;
                    }
                }

                if (!userFound)
                {
                    Console.WriteLine("Invalid email or password. Please try again.\n");
                    loginAttempts++; // Increment the login attempts counter
                    if (loginAttempts >= 3) // Check if the user has exceeded the maximum allowed attempts
                    {
                        Console.WriteLine("Too many failed login attempts. Please try again later.\n");
                        loginAttempts = 0; // Reset the counter
                        Program.DisplayMenu(); //goes back to the main menu
                    }
                    else
                    {
                        login(); //try to login again
                    }
                }
            }
        }

        Program.DisplayMenu();

        while (true)
        {
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                     if(count < users.Length) // check if the user array is not full
                    {
                        users[count] = new User(); //create a new user object
                        users[count].registeraUser(); //register the user
                        count++; //increment the count of registered users, for a new user in the array (would be different if we were using a DB)
                        users[count - 1].DisplayUserMenu();
                    }
                    else
                    {
                        Console.WriteLine(" XXX------>User limit reached!<------XXX\n"); //error message if the user array is full
                    }
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