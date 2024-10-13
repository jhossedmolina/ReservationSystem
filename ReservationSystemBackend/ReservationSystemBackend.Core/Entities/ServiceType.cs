namespace ReservationSystemBackend.Core.Entities;

public partial class ServiceType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
