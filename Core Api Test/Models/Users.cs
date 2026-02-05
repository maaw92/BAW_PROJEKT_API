namespace Core_Api_Test.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<SeatReservation> Reservations { get; set; }
        public string Name { get; set; }
        public bool IsManager { get; set; }

    }
}
