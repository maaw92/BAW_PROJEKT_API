using Microsoft.Extensions.Logging;

namespace Core_Api_Test.Models
{
    public class SeatReservation
    {
        public int Id { get; set; }       

        public int SeatId { get; set; }
        public Seat Seat { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

    }
}
