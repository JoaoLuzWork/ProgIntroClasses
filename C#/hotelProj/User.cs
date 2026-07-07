class User{
    int UserId { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    string Password { get; set; }
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

        userIdCounter++;
    }
}