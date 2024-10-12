using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ReservationSystemBackend.Core.Entities;
using ReservationSystemBackend.Infraestructure.Data.Configurations;

namespace ReservationSystemBackend.Infraestructure.Data;

public partial class ReservationSystemDbContext : DbContext
{
    public ReservationSystemDbContext()
    {
    }

    public ReservationSystemDbContext(DbContextOptions<ReservationSystemDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<ServiceType> ServiceTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientConfiguration).Assembly);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReservationConfiguration).Assembly);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ServiceTypeConfiguration).Assembly);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
