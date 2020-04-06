using FitnessCelebrity.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Data
{
    public class FitnessDbContext : DbContext
    {
        public DbSet<Movement> Movements { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<FitnessPath> FitnessPaths { get; set; }
        public DbSet<FitnessPathWorkout> FitnessPathWorkouts { get; set; }
        public DbSet<WorkoutMovement> WorkoutMovements { get; set; }
        public FitnessDbContext(DbContextOptions<FitnessDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FitnessPathWorkout>().HasKey(sc => new { sc.FitnessPathId, sc.WorkoutId });
            modelBuilder.Entity<WorkoutMovement>().HasKey(sc => new { sc.WorkoutId, sc.MovementId });
            
            modelBuilder.Entity<FitnessPathWorkout>()
            .HasOne<FitnessPath>(sc => sc.FitnessPath)
            .WithMany(s => s.FitnessPathWorkouts)
            .HasForeignKey(sc => sc.FitnessPathId);


            modelBuilder.Entity<FitnessPathWorkout>()
                .HasOne<Workout>(sc => sc.Workout)
                .WithMany(s => s.FitnessPathWorkouts)
                .HasForeignKey(sc => sc.WorkoutId);

            modelBuilder.Entity<WorkoutMovement>()
            .HasOne<Workout>(sc => sc.Workout)
            .WithMany(s => s.WorkoutMovements)
            .HasForeignKey(sc => sc.WorkoutId);


            modelBuilder.Entity<WorkoutMovement>()
                .HasOne<Movement>(sc => sc.Movement)
                .WithMany(s => s.WorkoutMovements)
                .HasForeignKey(sc => sc.MovementId);
        }

    }
}
