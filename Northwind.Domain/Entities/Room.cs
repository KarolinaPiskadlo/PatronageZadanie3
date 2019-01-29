namespace Northwind.Domain.Entities

{
    public class Room
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int NumberOfSeats { get; set; }
        public int Area { get; set; }
        public string Calendar { get; set; }
    }
}
