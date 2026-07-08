class Admin{    
    int AdminId { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    string PhoneNumber { get; set; }

    // Navigation property
    public List<Room> Rooms { get; set; } = new List<Room>();
    public int adminIdCounter = 1;

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

        Console.WriteLine("Enter your password: ");
        Password = Console.ReadLine();

        Program.admins[adminIdCounter] = new Admin(adminIdCounter, FirstName, LastName, Email, Password, PhoneNumber); // Store the new admin in the admins array
        adminIdCounter++;

        DisplayAdminMenu();
    }

    public void DisplayAdminMenu()
        {
            Console.WriteLine("\n=========== Admin Menu ===========");
            Console.WriteLine("1. Register a new admin");
            Console.WriteLine("2. List all admins");
            Console.WriteLine("3. Add Room");
            Console.WriteLine("4. Edit Room");
            Console.WriteLine("5. Edit availability of Room");
            Console.WriteLine("6. Delete Room");
            Console.WriteLine("7. View All Rooms");
            Console.WriteLine("8. View All Bookings");
            Console.WriteLine("9. Logout");
            Console.WriteLine("Please select an option:");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    registeraAdm();
                    break;
                case 2:
                    ListAllAdmins();
                    break;
                case 3:
                    Room.EditRoom();
                    break;
                case 4:
                    Room.EditAvailability();
                    break;
                case 5:
                    Room.DeleteRoom();
                    break;
                case 6:
                    Room.ViewAllRooms();
                    break;
                case 7:
                    Bookings.ViewAllBookings();
                    break;
                case 8:
                    Console.WriteLine("Logging out...\n\n");
                    Program.DisplayMenu();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    DisplayAdminMenu();
                    break;
            }
        }
        public void ListAllAdmins()
        {
            Console.WriteLine("\n=========== List of Admins ===========");
            for (int i=0; i < Program.admins.Length; i++)
            {
                Console.WriteLine($"Admin ID: {Program.admins[i].AdminId}, Name: {Program.admins[i].FirstName} {Program.admins[i].LastName}, Email: {Program.admins[i].Email}, Phone: {Program.admins[i].PhoneNumber}");                
            }
            Console.WriteLine("======================================\n");
            DisplayAdminMenu(); // Return to the main menu after listing admins
        }  

        public void ListAllUsers()
        {
            Console.WriteLine("\n=========== List of Users ===========");
            for (int i=0; i <= Program.users.Length; i++)
            {
                Console.WriteLine($"User ID: {Program.users[i].UserId}, Name: {Program.users[i].FirstName} {Program.users[i].LastName}, Email: {Program.users[i].Email}, Phone: {Program.users[i].PhoneNumber}");                
            }
            Console.WriteLine("======================================\n");
            DisplayAdminMenu(); // Return to the main menu after listing users
        }
}