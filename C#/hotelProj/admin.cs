class Admin{    
    int AdminId { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    string PhoneNumber { get; set; }

    // Navigation property
    public List<Room> Rooms { get; set; }
    int adminIdCounter = 1;

    public Admin(int adminId, string firstName, string lastName, string email, string password, string phoneNumber)
    {
        AdminId = adminId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
    }

    public void registeraAdm()
    {
        AdminId = adminIdCounter;

        Console.WriteLine("Enter first your name: ");
        FirstName = Console.ReadLine();

        Console.WriteLine("Enter your last name: ");
        LastName = Console.ReadLine();

        Console.WriteLine("Enter your email: ");
        Email = Console.ReadLine();

        Console.WriteLine("Enter your phone number: ");
        PhoneNumber = Console.ReadLine();

        adminIdCounter++;
    }

    public void DisplayAdminMenu()
        {
            Console.WriteLine("=========== Admin Menu ===========");
            Console.WriteLine("1. Add Room");
            Console.WriteLine("2. View All Bookings");
            Console.WriteLine("3. Logout");
            Console.WriteLine("Please select an option:");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Room.AddRoom();
                    break;
                case 2:
                    Bookings.ViewAllBookings();
                    break;
                case 3:
                    Console.WriteLine("Logging out...\n\n");
                    Program.DisplayMenu();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    DisplayAdminMenu();
                    break;
            }
        }  
}