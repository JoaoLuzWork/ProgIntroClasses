class Room
{
    int RoomId { get; set; }
    string RoomNumber { get; set; }
    string RoomType { get; set; }
    decimal PricePerNight { get; set; }
    bool IsAvailable { get; set; }

    public Room(int roomId, string roomNumber, string roomType, decimal pricePerNight, bool isAvailable)
    {
        RoomId = roomId;
        RoomNumber = roomNumber;
        RoomType = roomType;
        PricePerNight = pricePerNight;
        IsAvailable = isAvailable;
    }
}