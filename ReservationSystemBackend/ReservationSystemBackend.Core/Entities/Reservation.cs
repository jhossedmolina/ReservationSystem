namespace ReservationSystemBackend.Core.Entities;

public partial class Reservation
{
    public int Id { get; set; }

    public int IdClient { get; set; }

    public int IdServiceType { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ReservationDate { get; set; }

    public string? Details { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual ServiceType IdServiceTypeNavigation { get; set; } = null!;
}
