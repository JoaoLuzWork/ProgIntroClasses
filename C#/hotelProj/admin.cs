public class Admin{    
    int AdminId { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    string PhoneNumber { get; set; }
    
    public static int adminIdCounter = 1;

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
        Console.WriteLine("Enter first your name: ");
        string firstName = Console.ReadLine();

        Console.WriteLine("Enter your last name: ");
        string lastName = Console.ReadLine();

        Console.WriteLine("Enter your email: ");
        string email = Console.ReadLine();

        Console.WriteLine("Enter your phone number: ");
        string phoneNumber = Console.ReadLine();

        Console.WriteLine("Enter your password: ");
        string password = Console.ReadLine();

        // Add the new admin to the list of admins in the Program class no index needed. list was added to to the Program class to store all admins
        Program.admins.Add(new Admin(adminIdCounter, firstName, lastName, email, password, phoneNumber));
        adminIdCounter++;

        DisplayAdminMenu();
    }

    public void DisplayAdminMenu()
        {
            Console.WriteLine("\n=================================");
            Console.WriteLine("=========== Admin Menu ===========");
            Console.WriteLine("=================================\n");

            Console.WriteLine("1. Register a new admin");
            Console.WriteLine("2. View all admins");
            Console.WriteLine("3. View all users");
            Console.WriteLine("4. View All Bookings");
            Console.WriteLine("5. View All Rooms");
            Console.WriteLine("6. Add Room");
            Console.WriteLine("7. Edit Room");
            Console.WriteLine("8. Delete Room");
            Console.WriteLine("9. Add Bookings");
            Console.WriteLine("10. Edit Bookings");
            Console.WriteLine("11. Delete Bookings");
            Console.WriteLine("12. Logout");
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
                    ListAllUsers();
                    break;
                case 4:
                    Room.AddRoom();
                    break;
                case 5:
                    Room.EditRoom();
                    break;
                case 6:
                    Room.DeleteRoom();
                    break;
                case 7:
                    ListAllRooms();
                    break;
                case 8:
                    Bookings.AddBooking();
                    break;
                case 9:
                    Bookings.EditBooking();
                    break;
                case 10:
                    Bookings.DeleteBooking();
                    break;
                case 11:
                    ListAllBookings();
                    break;
                case 12:
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
            foreach (var admin in Program.admins)
            {
                Console.WriteLine($"Admin ID: {admin.AdminId}, Name: {admin.FirstName} {admin.LastName}, Email: {admin.Email}, Phone: {admin.PhoneNumber}");
            }
            Console.WriteLine("======================================\n");
            DisplayAdminMenu(); // Return to the main menu after listing admins
        }  

        public void ListAllUsers()
        {
            Console.WriteLine("\n=========== List of Users ===========");
            foreach (var user in Program.users)
            {
                Console.WriteLine($"User ID: {user.UserId}, Name: {user.FirstName} {user.LastName}, Email: {user.Email}, Phone: {user.PhoneNumber}");
            }
            Console.WriteLine("======================================\n");
            DisplayAdminMenu(); // Return to the main menu after listing users
        }

        public void ListAllBookings()
        {
            Console.WriteLine("\n=========== List of Bookings ===========");
            foreach (var booking in Program.bookings)
            {
                Console.WriteLine($"Booking ID: {booking.BookingId}, Room ID: {booking.RoomId}, Customer ID: {booking.CustomerId}, Check-In: {booking.CheckInDate}, Check-Out: {booking.CheckOutDate}, Total Amount: {booking.TotalAmount}");
            }
            Console.WriteLine("======================================\n");
            DisplayAdminMenu(); // Return to the main menu after listing bookings
        }

        public void ListAllRooms()
        {
            Console.WriteLine("\n=========== List of Rooms ===========");
            foreach (var room in Program.rooms)
            {
                Console.WriteLine($"Room ID: {room.RoomId}, Room Number: {room.RoomNumber}, Room Type: {room.RoomType}, Price per Night: {room.PricePerNight}, Is Available: {room.IsAvailable}");
            }
            Console.WriteLine("======================================\n");
            DisplayAdminMenu(); // Return to the main menu after listing rooms
        }

}