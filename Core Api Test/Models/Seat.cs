using Microsoft.Extensions.Logging;

namespace Core_Api_Test.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public MovieEvent Event { get; set; }

        public string SeatNumber { get; set; }
        public bool IsReserved { get; set; }

        public ICollection<SeatReservation> Reservations { get; set; }
    }
}
