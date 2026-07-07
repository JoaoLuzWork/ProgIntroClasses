class Admin{    
    int AdminId { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    string Password { get; set; }
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
}