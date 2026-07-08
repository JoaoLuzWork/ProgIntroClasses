
class Program
{
    public static void DisplayMenu()
        {
            Console.WriteLine("=========== Welcome to Hotel Silverstone! ===========\n");
            Console.WriteLine("if you are a new user, please register first!");
            Console.WriteLine("1.Registration");
            Console.WriteLine("2.Login");
            Console.WriteLine("3.Exit");
            Console.WriteLine("Please select an option:");
        }
    static void Main()
    {
        const int MAX_USERS = 2; // Avoid Hardcode
        User[] users = new User[MAX_USERS];

        const int MAX_ADMINS = 2;  // Avoid Hardcode
        Admin[] admins = new Admin[MAX_ADMINS];

        admins[0] = new Admin(0, "John", "Doe", "joao@gmail.com", "1234", "123-456-7890");
        int count = 0; 
    
        Program.DisplayMenu();

        void login()
        {
            Console.WriteLine("Enter your email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();

            if (email == admins[0].Email && password == admins[0].Password)
            {
                Console.WriteLine("Admin login successful!\n");
                admins[0].DisplayAdminMenu();
            }
            else
            {
                bool userFound = false;
                for (int i = 0; i < count; i++)
                {
                    if (users[i] != null && users[i].Email == email && users[i].Password == password)
                    {
                        Console.WriteLine("User login successful!\n");
                        users[i].DisplayUserMenu();
                        userFound = true;
                        break;
                    }
                }

                if (!userFound)
                {
                    Console.WriteLine("Invalid email or password. Please try again.");
                    login();
                }
            }
        }

        while (true)
        {
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                     if(count < users.Length)
                    {
                        users[count] = new User();
                        users[count].registeraUser();
                        count++; 
                        users[count - 1].DisplayUserMenu();
                    }
                    else
                    {
                        Console.WriteLine(" -----------> Error Message: No more patients can be registered in our system!");
                    }
                    break;
                case 2:
                    login();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}