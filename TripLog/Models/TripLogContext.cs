using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace TripLog.Models
{
    //By inheriting from DbContext, the TripLogContext class gains the ability to interact with the database.
    public class TripLogContext : DbContext
    {
        public TripLogContext(DbContextOptions<TripLogContext> options)
            : base(options)
        { }
        //These DbSets represent the corresponding database tables within the data context
        //and allow CRUD operations on the data.

        public DbSet<Trip> Trips { get; set; } = null!;
        public DbSet<Accommodation> Accommodations { get; set; } = null!;
        public DbSet<Destination> Destinations { get; set; } = null!;
        public DbSet<Activity> Activities { get; set; } = null!;
        public DbSet<TripActivity> TripActivities { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //This line configures the composite primary key for the TripActivity entity.
            //It specifies that the primary key consists of the combination of the TripId and ActivityId properties.
            modelBuilder.Entity<TripActivity>()
                .HasKey(ta => new { ta.TripId, ta.ActivityId });

            //It specifies that each TripActivity belongs to one Trip (HasOne(ta => ta.Trip))
            //and that each Trip can have many TripActivities 
            modelBuilder.Entity<TripActivity>()
                .HasOne(ta => ta.Trip)
                .WithMany(t => t.TripActivities)
                .HasForeignKey(ta => ta.TripId);

            //each TripActivity belongs to one Activity
            //and that each Activity can have many TripActivities
            modelBuilder.Entity<TripActivity>()
                .HasOne(ta => ta.Activity)
                .WithMany(a => a.TripActivities)
                .HasForeignKey(ta => ta.ActivityId);
        }

        //It configures the relationships between the TripActivity, Trip, 
        //    and Activity entities using Entity Framework Core's Fluent API.
    }

    
}