class Bookings
{
    public int BookingId { get; set; }
    int RoomId { get; set; }
    int CustomerId { get; set; }
    DateTime CheckInDate { get; set; }
    DateTime CheckOutDate { get; set; }
    public decimal TotalAmount { get; set; }

    // Navigation properties
    public Room Room { get; set; }
    public User User { get; set; }

    public Bookings(int bookingId, int roomId, int customerId, DateTime checkInDate, DateTime checkOutDate, decimal totalAmount)
    {
        BookingId = bookingId;
        RoomId = roomId;
        CustomerId = customerId;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        TotalAmount = totalAmount;
    }
}