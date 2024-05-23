using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectFitness.Domain;

namespace ProjectFitness.DAL.EF;

public class FitnessDbContext : DbContext
{
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<MemberExercise> MemberExercises { get; set; }
    public DbSet<Fitness> Fitnesses { get; set; }

    public FitnessDbContext(DbContextOptions options) : base(options)
    {
        ProjectFitnessInitializer.Initialize(this, true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=ProjectFitness.db");
        }

        optionsBuilder.LogTo(message => Debug.WriteLine(message), LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exercise>().ToTable("Exercise");
        modelBuilder.Entity<Exercise>().HasIndex(exercise => exercise.Id).IsUnique();
        
        modelBuilder.Entity<Member>().ToTable("Member");
        modelBuilder.Entity<Member>().HasIndex(member => member.Id).IsUnique();
        
        modelBuilder.Entity<Fitness>().ToTable("Fitness");
        modelBuilder.Entity<Fitness>().HasIndex(fitness => fitness.Id).IsUnique();

        modelBuilder.Entity<MemberExercise>().ToTable("MemberExercise");
        modelBuilder.Entity<MemberExercise>().HasIndex(memberExercise => memberExercise.Id).IsUnique();

        modelBuilder.Entity<Exercise>()
            .HasMany(e => e.MembersExercises)
            .WithOne(me => me.Exercise);

        modelBuilder.Entity<Member>()
                .HasMany(m => m.MembersExercises)
                .WithOne(me => me.Member);

        modelBuilder.Entity<MemberExercise>()
            .ToTable("MemberExercise")
            .HasKey("Id");

        modelBuilder.Entity<Fitness>()
                .HasMany(fitness => fitness.Members)
                .WithOne(m => m.Fitness);
    }
}