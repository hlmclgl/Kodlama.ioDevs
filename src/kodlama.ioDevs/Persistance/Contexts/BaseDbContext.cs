using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistance.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<ProgrammingLanguageTechnology> ProgrammingLanguageTechnologies { get; set; }
        public DbSet<GithubAddress> GithubAddresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //  base.OnConfiguring(
            //    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("KodlamaioDevsConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(pl =>
            {
                pl.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                pl.Property(p => p.Id).HasColumnName("Id");
                pl.Property(p => p.Name).HasColumnName("Name");
                pl.HasMany(p => p.ProgrammingLanguageTechnologies);
            });

            modelBuilder.Entity<ProgrammingLanguageTechnology>(a =>
            {
                a.ToTable("ProgrammingLanguageTechnologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasOne(p => p.ProgrammingLanguage);
            });

            modelBuilder.Entity<GithubAddress>(a =>
            {
                a.ToTable("GithubAddresses").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.GithubUrl).HasColumnName("GithubUrl");
                a.HasOne(p => p.User);
            });

            modelBuilder.Entity<User>(p =>
            {
                p.ToTable("Users").HasKey(u => u.Id);
                p.Property(u => u.Id).HasColumnName("Id");
                p.Property(u => u.FirstName).HasColumnName("FirstName");
                p.Property(u => u.LastName).HasColumnName("LastName");
                p.Property(u => u.Email).HasColumnName("Email");
                p.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt");
                p.Property(u => u.PasswordHash).HasColumnName("PasswordHash");
                p.Property(u => u.Status).HasColumnName("Status");
                p.Property(u => u.AuthenticatorType).HasColumnName("AuthenticatorType");
                p.HasMany(c => c.UserOperationClaims);
                p.HasMany(c => c.RefreshTokens);
            });

            modelBuilder.Entity<OperationClaim>(p =>
            {
                p.ToTable("OperationClaims").HasKey(o => o.Id);
                p.Property(o => o.Id).HasColumnName("Id");
                p.Property(o => o.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(p =>
            {
                p.ToTable("UserOperationClaims").HasKey(u => u.Id);
                p.Property(u => u.Id).HasColumnName("Id");
                p.Property(u => u.UserId).HasColumnName("UserId");
                p.Property(u => u.OperationClaimId).HasColumnName("OperationClaimId");
                p.HasOne(u => u.User);
                p.HasOne(u => u.OperationClaim);
            });

            modelBuilder.Entity<RefreshToken>(a =>
            {
                a.ToTable("RefreshTokens").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.Token).HasColumnName("Token");
                a.Property(p => p.Expires).HasColumnName("Expires");
                a.Property(p => p.Created).HasColumnName("Created");
                a.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
                a.Property(p => p.Revoked).HasColumnName("Revoked");
                a.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");
                a.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
                a.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");
                a.HasOne(p => p.User);
            });

            //data migration
            ProgrammingLanguage[] programmingLanguageEntitySeeds = { new(1, "C#"), new(2, "Java") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageEntitySeeds);

            ProgrammingLanguageTechnology[] programmingLanguageTechnologyEntitySeeds = { new(1, 1, ".Net"), new(2, 2,"Spring") };
            modelBuilder.Entity<ProgrammingLanguageTechnology>().HasData(programmingLanguageTechnologyEntitySeeds);
        }
    }
}
