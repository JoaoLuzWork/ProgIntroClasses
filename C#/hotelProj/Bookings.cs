public class Bookings
{
    public int BookingId { get; set; }
    public int RoomId { get; set; }
    public int CustomerId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public decimal TotalAmount { get; set; }

    // Navigation properties
    public Room Room { get; set; }
    public User User { get; set; }

    public static int bookIdCounter = 0;

    public Bookings(int bookingId, int roomId, int customerId, DateTime checkInDate, DateTime checkOutDate, decimal totalAmount)
    {
        BookingId = bookingId;
        RoomId = roomId;
        CustomerId = customerId;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        TotalAmount = totalAmount;
    }

    public static void AddBooking()
    {
        Console.WriteLine("==================================");
        Console.WriteLine("============ Add Booking ===========");
        Console.WriteLine("==================================");

        Console.WriteLine("Enter room Id: ");
        int roomId = Convert.ToInt32(Console.ReadLine());

        Room room = Program.rooms.Find(r => r.RoomId == roomId);
        if (room == null)
        {
            Console.WriteLine("Room not found. Please try again.");
            AddBooking(); // Call AddBooking again to allow the admin to try again
        }

        Console.WriteLine("Enter customer Id: ");
        int customerId = Convert.ToInt32(Console.ReadLine());

        User user = Program.users.Find(u => u.UserId == customerId);
        if (user == null)
        {
            Console.WriteLine("Customer not found. Please try again.");
            AddBooking(); // Call AddBooking again to allow the admin to try again
        }

        Console.WriteLine("Enter check-in date (yyyy-MM-dd): ");
        DateTime checkInDate = Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine("Enter check-out date (yyyy-MM-dd): ");
        DateTime checkOutDate = Convert.ToDateTime(Console.ReadLine());

        if (checkOutDate <= checkInDate)
        {
            Console.WriteLine("Check-out date must be after check-in date. Please try again.");
            AddBooking(); // Call AddBooking again to allow the admin to try again
        }

        int nights = (checkOutDate - checkInDate).Days;
        decimal totalAmount = nights * room.PricePerNight;

        Bookings newBooking = new Bookings(bookIdCounter, roomId, customerId, checkInDate, checkOutDate, totalAmount)
        {
            Room = room,
            User = user
        };

        Program.bookings.Add(newBooking);
        bookIdCounter++;
        room.IsAvailable = false;
        Console.WriteLine("Booking added successfully!");
        Program.admins[0].DisplayAdminMenu(); // Return to the admin menu after adding a booking
    }

    public static void EditBooking()
    {
        Console.WriteLine("\n==================================");
        Console.WriteLine("============ Edit Booking ===========");
        Console.WriteLine("==================================");

        Console.WriteLine("Enter the Booking Id you want to edit: ");
        int bookid = Convert.ToInt32(Console.ReadLine());

        Bookings bookingToEdit = Program.bookings.Find(b => b.BookingId == bookid);
        Room room = Program.rooms.Find(r => r.RoomId == bookingToEdit.RoomId);

        if (bookingToEdit != null)
        {
            Console.WriteLine("Enter check-in date (yyyy-MM-dd): ");
            DateTime newCheckInDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter check-out date (yyyy-MM-dd): ");
            DateTime newCheckOutDate = Convert.ToDateTime(Console.ReadLine());

            if (newCheckOutDate <= newCheckInDate)
            {
                Console.WriteLine("Check-out date must be after check-in date. Please try again.");
                EditBooking(); // Call EditBooking to allow the admin to try again
            }

            int nights = (newCheckOutDate - newCheckInDate).Days;
            decimal totalAmount = nights * room.PricePerNight;

            bookingToEdit.CheckInDate = newCheckInDate;
            bookingToEdit.CheckOutDate = newCheckOutDate;
            bookingToEdit.TotalAmount = totalAmount;
            
            Console.WriteLine("Room details updated successfully!");
            Program.admins[0].DisplayAdminMenu(); // Return to the admin menu after editing a room
        }
        else
        {
            Console.WriteLine("Room not found. Please try again.");
            EditBooking(); // Call EditRoom to allow the admin to try again
        }
    }

     public static void DeleteBooking()
    {
        Console.WriteLine("====================================");
        Console.WriteLine("============ Delete Booking ===========");
        Console.WriteLine("====================================");

        Console.WriteLine("Enter the Booking Id to delete: ");
        int bookid = Convert.ToInt32(Console.ReadLine());

        Bookings bookingToDelete = Program.bookings.Find(b => b.BookingId == bookid);

        if (bookingToDelete != null)
        {
            Room room = Program.rooms.Find(r => r.RoomId == bookingToDelete.RoomId);
            if (room != null)
            {
                room.IsAvailable = true;
            }

            Program.bookings.Remove(bookingToDelete);
            Console.WriteLine("Booking deleted successfully!");
            Program.admins[0].DisplayAdminMenu(); // Return to the admin menu after deleting a Booking
        }
        else
        {
            Console.WriteLine("Booking not found. Please try again.");
            DeleteBooking(); // Call DeleteBooking to allow the admin to try again
        }
    }

    public static void BookRoom()
    {
        // Logic to book a room
    }

    public static void ViewMyBookings()
    {
        // Logic to view user's bookings
    }

    public static void UpdateBooking()
    {
        
    }

    public static void CancelBooking()
    {
        // Logic to cancel a booking
    }

}