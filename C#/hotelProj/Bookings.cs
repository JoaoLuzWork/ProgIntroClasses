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
        Console.WriteLine("\n==================================");
        Console.WriteLine("============ Add Booking ===========");
        Console.WriteLine("==================================");

        Console.WriteLine("Enter room Id: ");
        int roomId = Convert.ToInt32(Console.ReadLine());

        Room room = Program.rooms.Find(r => r.RoomId == roomId);//find if room exists
        if (room == null)
        {
            Console.WriteLine("Room not found. Please try again.");
            AddBooking(); // Call AddBooking again to allow the admin to try again
            return; // stop this attempt: everything below would use a null room
        }

        Console.WriteLine("Enter customer Id: ");
        int customerId = Convert.ToInt32(Console.ReadLine());

        User user = Program.users.Find(u => u.UserId == customerId);//find if user exists
        if (user == null)
        {
            Console.WriteLine("Customer not found. Please try again.");
            AddBooking(); // Call AddBooking again to allow the admin to try again
            return; // stop this attempt: everything below would use a null user
        }

        Console.WriteLine("Enter check-in date (yyyy-MM-dd): ");
        DateTime checkInDate = Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine("Enter check-out date (yyyy-MM-dd): ");
        DateTime checkOutDate = Convert.ToDateTime(Console.ReadLine());

        if (checkOutDate <= checkInDate)
        {
            Console.WriteLine("Check-out date must be after check-in date. Please try again.");
            AddBooking(); // Call AddBooking again to allow the admin to try again
            return; // stop this attempt: the retry already handled the booking
        }

        int nights = (checkOutDate - checkInDate).Days;
        decimal totalAmount = nights * room.PricePerNight;

        Bookings newBooking = new Bookings(bookIdCounter, roomId, customerId, checkInDate, checkOutDate, totalAmount)
        {
            Room = room,
            User = user
        };

        Program.bookings.Add(newBooking);//add the new room that was locally built to the program list
        bookIdCounter++;
        room.IsAvailable = false;
        Console.WriteLine("\nBooking added successfully!");
        Program.currentAdmin.DisplayAdminMenu(); // Return to the admin menu after adding a booking
    }

    public static void EditBooking()
    {
        Console.WriteLine("\n==================================");
        Console.WriteLine("============ Edit Booking ===========");
        Console.WriteLine("==================================");

        Console.WriteLine("Enter the Booking Id you want to edit: ");
        int bookid = Convert.ToInt32(Console.ReadLine());

        Bookings bookingToEdit = Program.bookings.Find(b => b.BookingId == bookid);

        if (bookingToEdit != null)
        {
            //look the room up only after we know the booking exists
            Room room = Program.rooms.Find(r => r.RoomId == bookingToEdit.RoomId);
            if (room == null) //the room may have been deleted since the booking was made
            {
                Console.WriteLine("The room for this booking no longer exists.");
                Program.currentAdmin.DisplayAdminMenu();
                return;
            }

            Console.WriteLine("Enter check-in date (yyyy-MM-dd): ");
            DateTime newCheckInDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter check-out date (yyyy-MM-dd): ");
            DateTime newCheckOutDate = Convert.ToDateTime(Console.ReadLine());

            if (newCheckOutDate <= newCheckInDate)
            {
                Console.WriteLine("Check-out date must be after check-in date. Please try again.");
                EditBooking(); // Call EditBooking to allow the admin to try again
                return; // stop this attempt: the retry already handled the edit
            }

            int nights = (newCheckOutDate - newCheckInDate).Days;
            decimal totalAmount = nights * room.PricePerNight;

            bookingToEdit.CheckInDate = newCheckInDate;
            bookingToEdit.CheckOutDate = newCheckOutDate;
            bookingToEdit.TotalAmount = totalAmount;
            
            Console.WriteLine("Room details updated successfully!");
            Program.currentAdmin.DisplayAdminMenu(); // Return to the admin menu after editing a room
        }
        else
        {
            Console.WriteLine("Booking not found. Please try again.");
            EditBooking(); // Call EditBooking to allow the admin to try again
        }
    }

     public static void DeleteBooking()
    {
        Console.WriteLine("\n====================================");
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
            Program.currentAdmin.DisplayAdminMenu(); // Return to the admin menu after deleting a Booking
        }
        else
        {
            Console.WriteLine("Booking not found. Please try again.");
            DeleteBooking(); // Call DeleteBooking to allow the admin to try again
        }
    }

    public static void BookRoom()
    {
        Console.WriteLine("\n==================================");
        Console.WriteLine("============ Book a Room ===========");
        Console.WriteLine("==================================");

        Console.WriteLine("Enter room Id: ");
        int roomId = Convert.ToInt32(Console.ReadLine());

        Room room = Program.rooms.Find(r => r.RoomId == roomId);
        if (room == null || !room.IsAvailable)
        {
            Console.WriteLine("Room not found or unavailable. Please try again.");
            BookRoom(); // Call BookRoom again to allow the user to try again
            return; // stop this attempt: everything below would use a null room
        }

        Console.WriteLine("Enter check-in date (yyyy-MM-dd): ");
        DateTime checkInDate = Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine("Enter check-out date (yyyy-MM-dd): ");
        DateTime checkOutDate = Convert.ToDateTime(Console.ReadLine());

        if (checkOutDate <= checkInDate)
        {
            Console.WriteLine("Check-out date must be after check-in date. Please try again.");
            BookRoom(); // Call BookRoom again to allow the user to try again
            return; // stop this attempt: the retry already handled the booking
        }

        int nights = (checkOutDate - checkInDate).Days;
        decimal totalAmount = nights * room.PricePerNight;

        Bookings newBooking = new Bookings(bookIdCounter, roomId, Program.currentUser.UserId, checkInDate, checkOutDate, totalAmount)
        {
            Room = room,
            User = Program.currentUser
        };

        Program.bookings.Add(newBooking);
        bookIdCounter++;
        room.IsAvailable = false;
        Console.WriteLine("Room booked successfully!");
        User.DisplayUserMenu(); // Return to the user menu after booking
    }

    public static void ViewMyBookings()
    {
        Console.WriteLine("\n============ My Bookings ============");

        List<Bookings> myBookings = Program.bookings.FindAll(b => b.CustomerId == Program.currentUser.UserId);

        if (myBookings.Count == 0)
        {
            Console.WriteLine("\nYou have no bookings.");
        }
        else
        {
            foreach (Bookings booking in myBookings)
            {
                Console.WriteLine($"Booking Id: {booking.BookingId}, Room: {booking.Room?.RoomNumber}, Check-in: {booking.CheckInDate:yyyy-MM-dd}, Check-out: {booking.CheckOutDate:yyyy-MM-dd}, Total: {booking.TotalAmount:C}");
            }
        }
        Console.WriteLine("==================================");

        User.DisplayUserMenu(); // Return to the user menu
    }

    public static void UpdateBooking()
    {
        Console.WriteLine("\n==================================");
        Console.WriteLine("============ Update your Booking ===========");
        Console.WriteLine("==================================");

        Console.WriteLine("Enter the Booking Id you want to edit: ");
        int bookid = Convert.ToInt32(Console.ReadLine());
        Bookings bookingToEdit = Program.bookings.Find(b => b.BookingId == bookid && b.CustomerId == Program.currentUser.UserId);

        if (bookingToEdit != null)
        {
            Room room = Program.rooms.Find(r => r.RoomId == bookingToEdit.RoomId);
            if (room == null) //the room may have been deleted since the booking was made
            {
                Console.WriteLine("The room for this booking no longer exists.");
                User.DisplayUserMenu();
                return;
            }

            Console.WriteLine("Enter check-in date (yyyy-MM-dd): ");
            DateTime newCheckInDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter check-out date (yyyy-MM-dd): ");
            DateTime newCheckOutDate = Convert.ToDateTime(Console.ReadLine());

            if (newCheckOutDate <= newCheckInDate)
            {
                Console.WriteLine("Check-out date must be after check-in date. Please try again.");
                UpdateBooking(); // Call UpdateBooking to allow the user to try again
                return; // stop this attempt: the retry already handled the update
            }

            int nights = (newCheckOutDate - newCheckInDate).Days;
            decimal totalAmount = nights * room.PricePerNight;

            bookingToEdit.CheckInDate = newCheckInDate;
            bookingToEdit.CheckOutDate = newCheckOutDate;
            bookingToEdit.TotalAmount = totalAmount;

            Console.WriteLine("Booking updated successfully!");
            User.DisplayUserMenu(); // Return to the user menu after editing a booking
        }
        else
        {
            Console.WriteLine("Booking not found. Please try again.");
            UpdateBooking(); // Call UpdateBooking to allow the user to try again
        }
    }

    public static void CancelBooking()
    {
        Console.WriteLine("\n====================================");
        Console.WriteLine("============ Cancel Booking ===========");
        Console.WriteLine("====================================");

        Console.WriteLine("Enter the Booking Id to cancel: ");
        int bookid = Convert.ToInt32(Console.ReadLine());

        Bookings bookingToDelete = Program.bookings.Find(b => b.BookingId == bookid && b.CustomerId == Program.currentUser.UserId);

        //receives booking id and check if it exists
        if (bookingToDelete != null)
        {
            //then finds romm id to set as available as the booking is being canceled
            Room room = Program.rooms.Find(r => r.RoomId == bookingToDelete.RoomId);
            if (room != null)
            {
                room.IsAvailable = true;
            }

            //then delete it
            Program.bookings.Remove(bookingToDelete);
            Console.WriteLine("Booking cancelled successfully!");
            User.DisplayUserMenu(); // Return to the user menu after cancelling a booking
        }
        else
        {
            Console.WriteLine("Booking not found. Please try again.");
            CancelBooking(); // Call CancelBooking to allow the user to try again
        }
    }

}