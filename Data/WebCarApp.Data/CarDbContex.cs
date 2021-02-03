using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace WebCarApp.Data
{
    using Models;
    public class CarDbContex : DbContext
    {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Car> Cars { get; set; }

        public DbSet<Engine> Engines { get; set; }

        public DbSet<Model> Models { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<Client> Clients { get; set; }
        /// <summary>
        /// no reference. Add Reference Later in order to connect with CarsExtras !!!
        /// </summary>
        public DbSet<CarExtras> CarsExtras { get; set; }
        public DbSet<Order> Orders { get; set; }


        public CarDbContex(DbContextOptions<CarDbContex> options)
        : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Car>(car =>
            {
                car.HasKey(e => e.Id).HasName("PK_Car");
                car.Property(e => e.Id).ValueGeneratedOnAdd();

                car
               .HasOne(m => m.Model)
               .WithMany(m => m.Cars)
               .HasForeignKey(c => c.ModelId);
            });
            modelBuilder.Entity<Make>(make =>
            {
                make.HasKey(e => e.Id).HasName("PK_Make");
                make.Property(e => e.Id).ValueGeneratedOnAdd();

                modelBuilder.Entity<Make>()
               .HasMany(m => m.Models)
               .WithOne(m => m.Make)
               .HasForeignKey(m => m.MakeId);
            });
            modelBuilder.Entity<Engine>(engine =>
            {
                engine.HasKey(e => e.Id).HasName("PK__Engines__3214EC077F4C4428");
                engine.Property(e => e.Id).ValueGeneratedOnAdd();

                modelBuilder.Entity<Engine>()
               .HasMany(m => m.Cars)
               .WithOne(e => e.Engine)
               .HasForeignKey(e => e.EngineId);
            });
            modelBuilder.Entity<Model>(c =>
            {
                c.HasKey(e => e.Id).HasName("PK_Model");
                c.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Client>(client =>
            {
                client.HasKey(e => e.Id).HasName("PK__Clients__3214EC072E87A576");
                client.Property(e => e.Id).ValueGeneratedOnAdd();


            });
            modelBuilder.Entity<CarExtras>(ce =>
            {
                ce.HasKey(c => new { c.CarId, c.ExtraId });

                ce.HasOne(c => c.Car)
                .WithMany(c => c.CarExtras)
                .HasForeignKey(p => p.CarId)
                .OnDelete(DeleteBehavior.Restrict);

                ce.HasOne(c => c.Extra)
             .WithMany(c => c.CarExtras)
             .HasForeignKey(p => p.ExtraId)
             .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Order>(order =>
                {
                    order.HasKey(x => new { x.CarId, x.ClientId });

                    order.HasOne(x => x.Client)
                    .WithMany(x => x.Orders)
                    .HasForeignKey(x => x.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);

                    order.HasOne(x => x.Car)
                  .WithMany(x => x.Orders)
                  .HasForeignKey(x => x.CarId)
                   .OnDelete(DeleteBehavior.Restrict);
                });


        }
    }
}