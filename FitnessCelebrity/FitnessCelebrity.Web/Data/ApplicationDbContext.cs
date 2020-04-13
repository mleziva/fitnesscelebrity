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
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FitnessPathWorkout>().HasKey(sc => new { sc.FitnessPathId, sc.WorkoutId });
            modelBuilder.Entity<WorkoutMovement>().HasKey(sc => new { sc.WorkoutId, sc.MovementId });

            //many-to-many relationship for entities
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
            modelBuilder.Entity<SubscribedFitnessPaths>().HasKey(sc => new { sc.ApplicationUserId, sc.FitnessPathId });
            modelBuilder.Entity<SubscribedUsers>().HasKey(sc => new { sc.ApplicationUserId, sc.UserProfileId });
            modelBuilder.Entity<SubscribedWorkouts>().HasKey(sc => new { sc.ApplicationUserId, sc.WorkoutId });

            modelBuilder.Entity<SubscribedFitnessPaths>()
            .HasOne<ApplicationUser>(sc => sc.ApplicationUser)
            .WithMany(s => s.SubscribedFitnessPaths)
            .HasForeignKey(sc => sc.ApplicationUserId);

            modelBuilder.Entity<SubscribedFitnessPaths>()
            .HasOne<FitnessPath>(sc => sc.FitnessPath)
            .WithMany(s => s.Subscriptions)
            .HasForeignKey(sc => sc.FitnessPathId);

            modelBuilder.Entity<SubscribedUsers>()
            .HasOne<ApplicationUser>(sc => sc.ApplicationUser)
            .WithMany(s => s.SubscribedUsers)
            .HasForeignKey(sc => sc.ApplicationUserId);

            modelBuilder.Entity<SubscribedUsers>()
            .HasOne<UserProfile>(sc => sc.UserProfile)
            .WithMany(s => s.Subscriptions)
            .HasForeignKey(sc => sc.UserProfileId);

            modelBuilder.Entity<SubscribedWorkouts>()
           .HasOne<ApplicationUser>(sc => sc.ApplicationUser)
           .WithMany(s => s.SubscribedWorkouts)
           .HasForeignKey(sc => sc.ApplicationUserId);

            modelBuilder.Entity<SubscribedWorkouts>()
            .HasOne<Workout>(sc => sc.Workout)
            .WithMany(s => s.Subscriptions)
            .HasForeignKey(sc => sc.WorkoutId);
        }
    }
}
