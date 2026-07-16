using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using YourMusicDepotApp.Models;

namespace YourMusicDepotApp.Data
{
    // Inherits from DbContext, a base class provided by Entity Framework for interacting with a database using objects.
    public class YourMusicDepotContext : DbContext
    {
        // DbSet properties represent collections of entities that can be queried and saved.
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorAvailability> InstructorAvailabilities { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentMusicProgress> StudentMusicProgresses { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<MusicLesson> MusicLessons { get; set; }
        public DbSet<MartialArtsLesson> MartialArtsLessons { get; set; }
        public DbSet<MusicLessonPayment> MusicLessonPayments { get; set; }

        // Configures the database to be used for this context.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Ensures the configuration is not already set.
            if (!optionsBuilder.IsConfigured)
            {
                // Builds configuration from JSON files next to the executable.
                // appsettings.local.json is an optional, uncommitted overlay for
                // machine-specific values.
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true)
                    .Build();

                // Retrieves the database connection string.
                var connectionString = configuration.GetConnectionString("YourMusicDepotDatabase");
                // Sets up the use of a SQL Server database with the connection string.
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        // Configures the model that was discovered by convention from the entity types exposed in DbSet properties.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Calls the base implementation of OnModelCreating.
            base.OnModelCreating(modelBuilder);
            // Fluent API configurations
            // Map the StudentMusicProgress entity to the StudentMusicProgress table
            modelBuilder.Entity<StudentMusicProgress>().ToTable("StudentMusicProgress");
            // Maps the InstructorAvailability class to the InstructorAvailability table in the database.
            modelBuilder.Entity<InstructorAvailability>().ToTable("InstructorAvailability");

            // Configurations for MusicLesson entity relationships.
            modelBuilder.Entity<MusicLesson>()
                .HasOne(ml => ml.Instructor) // Specifies a one-to-many relationship between Instructor and MusicLesson.
                .WithMany(i => i.MusicLessons)
                .HasForeignKey(ml => ml.InstructorID);

            modelBuilder.Entity<MusicLesson>()
                .HasOne(ml => ml.Student)
                .WithMany(s => s.MusicLessons)
                .HasForeignKey(ml => ml.StudentID);

            modelBuilder.Entity<MusicLesson>()
                .HasOne(ml => ml.Room)
                .WithMany(r => r.MusicLessons)
                .HasForeignKey(ml => ml.RoomID);
            modelBuilder.Entity<MusicLesson>()
            .HasOne(ml => ml.MusicLessonPayment)
            .WithOne(mlp => mlp.MusicLesson)
            .HasForeignKey<MusicLessonPayment>(mlp => mlp.MusicLessonID)
            .OnDelete(DeleteBehavior.Cascade);


            // Configure one-to-many relationship between Instructor and InstructorAvailability
            modelBuilder.Entity<Instructor>()
            .HasMany(i => i.MusicLessons)
            .WithOne(ml => ml.Instructor)
            .HasForeignKey(ml => ml.InstructorID)
            .OnDelete(DeleteBehavior.Cascade);

            // Configure one-to-many relationship between Room and MartialArtsLesson
            modelBuilder.Entity<Room>()
                .HasMany(r => r.MartialArtsLessons)
                .WithOne(mal => mal.Room)
                .HasForeignKey(mal => mal.RoomID);

            // Configure one-to-many relationship between Room and MusicLesson
            modelBuilder.Entity<Room>()
                .HasMany(r => r.MusicLessons)
                .WithOne(ml => ml.Room)
                .HasForeignKey(ml => ml.RoomID);

            // Configure one-to-many relationship between Student and StudentMusicProgress
            modelBuilder.Entity<Student>()
                .HasMany(s => s.StudentMusicProgresses)
                .WithOne(smp => smp.Student)
                .HasForeignKey(smp => smp.StudentID);

            // Configure one-to-one relationship between MusicLesson and MusicLessonPayment
            modelBuilder.Entity<MusicLessonPayment>()
                .HasOne(mlp => mlp.MusicLesson)
                .WithOne(ml => ml.MusicLessonPayment)
                .HasForeignKey<MusicLessonPayment>(mlp => mlp.MusicLessonID);
        }
    }
}
