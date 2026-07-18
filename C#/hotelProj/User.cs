public class User{
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }

    // Navigation property
    public List<Bookings> Bookings { get; set; }
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

    public void DisplayUserMenu()
        {
            Console.WriteLine("\n=================================");
            Console.WriteLine("=========== User Menu ===========");
            Console.WriteLine("=================================\n");

            Console.WriteLine("1. View Available Rooms");
            Console.WriteLine("2. Book a Room");
            Console.WriteLine("3. View My Bookings");
            Console.WriteLine("4. Logout");
            Console.WriteLine("Please select an option:");

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
                    Console.WriteLine("Logging out...");
                    Program.DisplayMenu(); // Return to the main menu
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

}