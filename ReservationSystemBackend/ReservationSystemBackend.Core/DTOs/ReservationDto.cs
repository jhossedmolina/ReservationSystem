namespace ReservationSystemBackend.Core.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }

        public int IdClient { get; set; }

        public int IdServiceType { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ReservationDate { get; set; }

        public string? Details { get; set; }
    }
}
