
class Program
{
    static void Main()
    {
        const int MAX_USERS = 10; // Avoid Hardcode
        User[] users = new User[MAX_USERS];

        const int MAX_ADMINS = 5;  // Avoid Hardcode
        Admin[] admins = new Admin[MAX_ADMINS];

        admins[0] = new Admin(0, "John", "Doe", "john.doe@example.com", "password123", "123-456-7890");
        int count = 0; 
        
        void DisplayMenu()
        {
            Console.WriteLine("=========== Welcome to Hotel Silverstone! ===========");
            Console.WriteLine("if you are a new user, please register first!");
            Console.WriteLine("1.Registration");
            Console.WriteLine("2.Login");
            Console.WriteLine("3.Exit");
            Console.WriteLine("Please select an option:");
        }
    
        DisplayMenu();
        
        
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
                        DisplayUserMenu();
                    }
                    else
                    {
                        Console.WriteLine(" -----------> Error Message: No more patients can be registered in our system!");
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter your email: ");
                    string email = Console.ReadLine();
                    Console.WriteLine("Enter your password: ");
                    string password = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
            
        void DisplayUserMenu()
        {
            Console.WriteLine("=========== User Menu ===========");
            Console.WriteLine("1. View Available Rooms");
            Console.WriteLine("2. Book a Room");
            Console.WriteLine("3. View My Bookings");
            Console.WriteLine("4. Logout");
            Console.WriteLine("Please select an option:");
        }

        void DisplayAdminMenu()
        {
            Console.WriteLine("=========== Admin Menu ===========");
            Console.WriteLine("1. Add Room");
            Console.WriteLine("2. View All Bookings");
            Console.WriteLine("3. Logout");
            Console.WriteLine("Please select an option:");
        }   
    }
}