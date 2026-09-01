public class Room
{
    public int RoomId { get; set; }
    public string RoomNumber { get; set; } = "";
    public string RoomType { get; set; } = "";
    public decimal PricePerNight { get; set; }
    public bool IsAvailable { get; set; }

    public static int roomIdCounter = 3; // Start from 3 since we already have 3 rooms in the list

    //constructor
    public Room(int roomId, string roomNumber, string roomType, decimal pricePerNight, bool isAvailable)
    {
        RoomId = roomId;
        RoomNumber = roomNumber;
        RoomType = roomType;
        PricePerNight = pricePerNight;
        IsAvailable = isAvailable;
    }

    //add new room to the program array of rooms
    public static void AddRoom()
    {

        Console.WriteLine("==================================");
        Console.WriteLine("============ Add Room ===========");
        Console.WriteLine("==================================");
        
        Console.WriteLine("Enter room number: ");
        string roomNumber = Console.ReadLine();

        Console.WriteLine("Enter room type: ");
        string roomType = Console.ReadLine();

        Console.WriteLine("Enter price per night: ");
        decimal pricePerNight = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Enter availability (true/false): ");
        bool isAvailable = Convert.ToBoolean(Console.ReadLine());

        Program.rooms.Add(new Room(roomIdCounter, roomNumber.ToString(), roomType, pricePerNight, isAvailable));
        roomIdCounter++;
        Console.WriteLine("Room added successfully!");

        Program.currentAdmin.DisplayAdminMenu(); // Return to the admin menu after adding a room
    }

    //edit a selected room
    public static void EditRoom()
    {
        Console.WriteLine("\n==================================");
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
            Program.currentAdmin.DisplayAdminMenu(); // Return to the admin menu after editing a room
        }
        else
        {
            Console.WriteLine("Room not found. Please try again.");
            EditRoom(); // Call EditRoom again to allow the admin to try again
        }
    }

    //Edit availability of a specific room
    public static void EditAvailability()
    {
        Console.WriteLine("\n==========================================");
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
            Program.currentAdmin.DisplayAdminMenu(); // Return to the admin menu after editing availability
        }
        else
        {
            Console.WriteLine("Room not found. Please try again.");
            EditAvailability(); // Call EditAvailability again to allow the admin to try again
        }
    }

    //delete selected room
    public static void DeleteRoom()
    {
        Console.WriteLine("\n====================================");
        Console.WriteLine("============ Delete Room ===========");
        Console.WriteLine("====================================");

        Console.WriteLine("Enter the room number you want to delete: ");
        string roomNumber = Console.ReadLine();

        Room roomToDelete = Program.rooms.Find(r => r.RoomNumber == roomNumber);

        if (roomToDelete != null)
        {
            Program.rooms.Remove(roomToDelete);
            Console.WriteLine("Room deleted successfully!");
            Program.currentAdmin.DisplayAdminMenu(); // Return to the admin menu after deleting a room
        }
        else
        {
            Console.WriteLine("Room not found. Please try again.");
            DeleteRoom(); // Call DeleteRoom again to allow the admin to try again
        }
    }

    //for each room that is available it will print here
    public static void AvailableRooms()
    {
        Console.WriteLine("\n=========== List of Availavle Rooms ===========");
        foreach (Room r in Program.rooms.FindAll(r => r.IsAvailable == true))
        {
            Console.WriteLine($"Room {r.RoomNumber} is available. This room is {r.RoomType} Room. The price is {r.PricePerNight}");
        }
        Console.WriteLine("===============================================\n");
        User.DisplayUserMenu();
    }
}