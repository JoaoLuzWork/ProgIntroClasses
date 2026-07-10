class Room
{
    public int RoomId { get; set; }
    public string RoomNumber { get; set; }
    public string RoomType { get; set; }
    public decimal PricePerNight { get; set; }
    public bool IsAvailable { get; set; }

    public static int roomIdCounter = 3; // Start from 3 since we already have 3 rooms in the list

    public Room(int roomId, string roomNumber, string roomType, decimal pricePerNight, bool isAvailable)
    {
        RoomId = roomId;
        RoomNumber = roomNumber;
        RoomType = roomType;
        PricePerNight = pricePerNight;
        IsAvailable = isAvailable;
    }

    public static void AddRoom()
    {

        Console.WriteLine("==================================");
        Console.WriteLine("============ Add Room ===========");
        Console.WriteLine("==================================");
        
        Console.WriteLine("Enter room number: ");
        int roomNumber = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter room type: ");
        string roomType = Console.ReadLine();

        Console.WriteLine("Enter price per night: ");
        decimal pricePerNight = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Enter availability (true/false): ");
        bool isAvailable = Convert.ToBoolean(Console.ReadLine());

        Program.rooms.Add(new Room(roomIdCounter, roomNumber.ToString(), roomType, pricePerNight, isAvailable));
        roomIdCounter++;
        Console.WriteLine("Room added successfully!");

        Program.admins[0].DisplayAdminMenu(); // Return to the admin menu after adding a room
    }

    public static void EditRoom()
    {
        Console.WriteLine("==================================");
        Console.WriteLine("============ Edit Room ===========");
        Console.WriteLine("==================================");


        Console.WriteLine("Enter the room number you want to edit: ");
        string roomNumber = Console.ReadLine();

        Room roomToEdit = Program.rooms.Find(r => r.RoomNumber == roomNumber);

        if (roomToEdit != null)
        {
            Console.WriteLine("Enter new room type: ");
            string newRoomType = Console.ReadLine();

            Console.WriteLine("Enter new price per night: ");
            decimal newPricePerNight = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter new availability (true/false): ");
            bool newIsAvailable = Convert.ToBoolean(Console.ReadLine());

            roomToEdit.RoomType = newRoomType;
            roomToEdit.PricePerNight = newPricePerNight;
            roomToEdit.IsAvailable = newIsAvailable;

            Console.WriteLine("Room details updated successfully!");
            Program.admins[0].DisplayAdminMenu(); // Return to the admin menu after editing a room
        }
        else
        {
            Console.WriteLine("Room not found. Please try again.");
            EditRoom(); // Call EditRoom again to allow the admin to try again
        }
    }

    public static void EditAvailability()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("============ Edit Availability ===========");
        Console.WriteLine("==========================================");
      
        Console.WriteLine("Enter the room number you want to edit availability for: ");
        string roomNumber = Console.ReadLine();

        Room roomToEdit = Program.rooms.Find(r => r.RoomNumber == roomNumber);

        if (roomToEdit != null)
        {
            Console.WriteLine("Enter new availability (true/false): ");
            bool newIsAvailable = Convert.ToBoolean(Console.ReadLine());

            roomToEdit.IsAvailable = newIsAvailable;

            Console.WriteLine("Room availability updated successfully!");
        }
        else
        {
            Console.WriteLine("Room not found. Please try again.");
            EditAvailability(); // Call EditAvailability again to allow the admin to try again
        }
    }

    public static void DeleteRoom()
    {
        Console.WriteLine("====================================");
        Console.WriteLine("============ Delete Room ===========");
        Console.WriteLine("====================================");

        Console.WriteLine("Enter the room number you want to delete: ");
        string roomNumber = Console.ReadLine();

        Room roomToDelete = Program.rooms.Find(r => r.RoomNumber == roomNumber);

        if (roomToDelete != null)
        {
            Program.rooms.Remove(roomToDelete);
            Console.WriteLine("Room deleted successfully!");
            Program.admins[0].DisplayAdminMenu(); // Return to the admin menu after deleting a room
        }
        else
        {
            Console.WriteLine("Room not found. Please try again.");
            DeleteRoom(); // Call DeleteRoom again to allow the admin to try again
        }
    }
}