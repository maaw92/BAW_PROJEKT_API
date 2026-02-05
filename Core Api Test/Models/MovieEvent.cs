namespace Core_Api_Test.Models
{
    public class MovieEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public ICollection<Seat> Seats { get; set; }
        public ICollection<SeatReservation> Reservations { get; set; }
    }
}
