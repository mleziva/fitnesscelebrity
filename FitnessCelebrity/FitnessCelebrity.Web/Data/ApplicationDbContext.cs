using FitnessCelebrity.Web.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessCelebrity.Web.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<FitnessPath> FitnessPaths { get; set; }
        public DbSet<FitnessPathWorkout> FitnessPathWorkouts { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutMovement> WorkoutMovements { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<WorkoutHistory> WorkoutHistories { get; set; }
        public DbSet<FitnessPathHistory> FitnessPathHistories { get; set; }
        public DbSet<DailyLog> DailyLogs { get; set; }
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //many-to-many relationship for entities
            modelBuilder.Entity<FitnessPathWorkout>()
            .HasOne<FitnessPath>(sc => sc.FitnessPath)
            .WithMany(s => s.FitnessPathWorkouts)
            .HasForeignKey(sc => sc.FitnessPathId);

            modelBuilder.Entity<FitnessPathWorkout>()
                .HasOne<Workout>(sc => sc.Workout)
                .WithMany(s => s.FitnessPathWorkouts)
                .HasForeignKey(sc => sc.WorkoutId);

            modelBuilder.Entity<FitnessPathWorkout>()
          .HasOne<ApplicationUser>(s => s.CreatedByUser)
          .WithMany(g => g.CreatedFitnessPathWorkouts)
          .HasForeignKey(s => s.CreatedById);

            modelBuilder.Entity<FitnessPathWorkout>()
             .HasOne<ApplicationUser>(s => s.ModifiedByUser)
             .WithMany(g => g.ModifiedFitnessPathWorkouts)
             .HasForeignKey(s => s.ModifiedById);


            modelBuilder.Entity<WorkoutMovement>().HasKey(sc => new { sc.WorkoutId, sc.MovementId });

            modelBuilder.Entity<WorkoutMovement>()
            .HasOne<Workout>(sc => sc.Workout)
            .WithMany(s => s.WorkoutMovements)
            .HasForeignKey(sc => sc.WorkoutId);


            modelBuilder.Entity<WorkoutMovement>()
                .HasOne<Movement>(sc => sc.Movement)
                .WithMany(s => s.WorkoutMovements)
                .HasForeignKey(sc => sc.MovementId);

            // configures one-to-many relationship for createdBy and modifiedBy
            modelBuilder.Entity<FitnessPath>()
            .HasOne<ApplicationUser>(s => s.CreatedByUser)
            .WithMany(g => g.CreatedFitnessPaths)
            .HasForeignKey(s => s.CreatedById);

            modelBuilder.Entity<Workout>()
            .HasOne<ApplicationUser>(s => s.CreatedByUser)
            .WithMany(g => g.CreatedWorkouts)
            .HasForeignKey(s => s.CreatedById);

            modelBuilder.Entity<Movement>()
            .HasOne<ApplicationUser>(s => s.CreatedByUser)
            .WithMany(g => g.CreatedMovements)
            .HasForeignKey(s => s.CreatedById);

            modelBuilder.Entity<FitnessPath>()
             .HasOne<ApplicationUser>(s => s.ModifiedByUser)
             .WithMany(g => g.ModifiedFitnessPaths)
             .HasForeignKey(s => s.ModifiedById);

            modelBuilder.Entity<Workout>()
            .HasOne<ApplicationUser>(s => s.ModifiedByUser)
            .WithMany(g => g.ModifiedWorkouts)
            .HasForeignKey(s => s.ModifiedById);

            modelBuilder.Entity<Movement>()
            .HasOne<ApplicationUser>(s => s.ModifiedByUser)
            .WithMany(g => g.ModifiedMovements)
            .HasForeignKey(s => s.ModifiedById);

            //add user profile relationship 1:1
            modelBuilder.Entity<UserProfile>()
           .HasOne<ApplicationUser>(s => s.ApplicationUser)
           .WithOne(g => g.UserProfile)
           .HasForeignKey<UserProfile>(s => s.ApplicationUserId);

            //add subscriptions relationships many:many

            modelBuilder.Entity<FitnessPathSubscription>()
            .HasOne<ApplicationUser>(sc => sc.ApplicationUser)
            .WithMany(s => s.FitnessPathSubscriptions)
            .HasForeignKey(sc => sc.ApplicationUserId);

            modelBuilder.Entity<FitnessPathSubscription>()
            .HasOne<FitnessPath>(sc => sc.FitnessPath)
            .WithMany(s => s.Subscriptions)
            .HasForeignKey(sc => sc.FitnessPathId);

            modelBuilder.Entity<UserSubscription>()
            .HasOne<ApplicationUser>(sc => sc.ApplicationUser)
            .WithMany(s => s.UserSubscriptions)
            .HasForeignKey(sc => sc.ApplicationUserId);

            modelBuilder.Entity<UserSubscription>()
            .HasOne<UserProfile>(sc => sc.UserProfile)
            .WithMany(s => s.Subscriptions)
            .HasForeignKey(sc => sc.UserProfileId);

            modelBuilder.Entity<WorkoutSubscription>()
           .HasOne<ApplicationUser>(sc => sc.ApplicationUser)
           .WithMany(s => s.WorkoutSubscriptions)
           .HasForeignKey(sc => sc.ApplicationUserId);

            modelBuilder.Entity<WorkoutSubscription>()
            .HasOne<Workout>(sc => sc.Workout)
            .WithMany(s => s.Subscriptions)
            .HasForeignKey(sc => sc.WorkoutId);

            //workout history 1:many
            modelBuilder.Entity<WorkoutHistory>()
            .HasOne<ApplicationUser>(s => s.User)
            .WithMany(g => g.WorkoutHistories)
            .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<WorkoutHistory>()
            .HasOne<FitnessPathHistory>(s => s.FitnessPathHistory)
            .WithMany(g => g.WorkoutHistories)
            .HasForeignKey(s => s.FitnessPathHistoryId);

            modelBuilder.Entity<WorkoutHistory>()
            .HasOne<Workout>(s => s.Workout)
            .WithMany(g => g.WorkoutHistories)
            .HasForeignKey(s => s.WorkoutId);

            //daily log 1:many
            modelBuilder.Entity<DailyLog>()
            .HasOne<WorkoutHistory>(s => s.WorkoutHistory)
            .WithMany(g => g.DailyLogs)
            .HasForeignKey(s => s.WorkoutHistoryId);

            modelBuilder.Entity<DailyLog>()
            .HasOne<ApplicationUser>(s => s.User)
            .WithMany(g => g.DailyLogs)
            .HasForeignKey(s => s.UserId);

            //FitnessPath history 1:many
            modelBuilder.Entity<FitnessPathHistory>()
            .HasOne<ApplicationUser>(s => s.User)
            .WithMany(g => g.FitnessPathHistories)
            .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<FitnessPathHistory>()
            .HasOne<FitnessPath>(s => s.FitnessPath)
            .WithMany(g => g.FitnessPathHistories)
            .HasForeignKey(s => s.FitnessPathId);

        }
    }
}
