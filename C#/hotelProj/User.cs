class User{
    int UserId { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    string PhoneNumber { get; set; }

    // Navigation property
    public List<Bookings> Bookings { get; set; }

    int userIdCounter = 0;

    public void registeraUser()
    {
        UserId = userIdCounter;

        Console.WriteLine("Enter your first name: ");
        FirstName = Console.ReadLine();

        Console.WriteLine("Enter your last name: ");
        LastName = Console.ReadLine();

        Console.WriteLine("Enter your email: ");
        Email = Console.ReadLine();

        Console.WriteLine("Enter your phone number: ");
        PhoneNumber = Console.ReadLine();

        Password = "1234"; // Default password for simplicity

        userIdCounter++;
    }

    public void DisplayUserMenu()
        {
            Console.WriteLine("=========== User Menu ===========");
            Console.WriteLine("1. View Available Rooms");
            Console.WriteLine("2. Book a Room");
            Console.WriteLine("3. View My Bookings");
            Console.WriteLine("4. Logout");
            Console.WriteLine("Please select an option:");

            while(true)
            {
                int userOption = Convert.ToInt32(Console.ReadLine());
                switch (userOption)
                {
                    case 1:
                        // Logic to view available rooms
                        break;
                    case 2:
                        // Logic to book a room
                        break;
                    case 3:
                        // Logic to view my bookings
                        break;
                    case 4:
                        Console.WriteLine("Logging out...\n\n");
                        Program.DisplayMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

}