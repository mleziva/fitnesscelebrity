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
        }
    }
}
