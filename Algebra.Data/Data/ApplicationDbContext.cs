using Algebra.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Algebra.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext() { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<ApplicationUser>().ToTable("User");
            builder.Entity<ApplicationUser>().HasMany(u => u.Tokens).WithOne(i => i.User);

            builder.Entity<Member>().ToTable("Member");
            builder.Entity<Member>().Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Entity<Member>().HasMany(d => d.Dependents).WithOne(m => m.Member);

            builder.Entity<Dependent>().ToTable("Dependent");
            builder.Entity<Dependent>().Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Entity<Dependent>().HasOne(m => m.Member).WithMany(d => d.Dependents);

            builder.Entity<Spouse>().ToTable("Spouse");
            builder.Entity<Spouse>().Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Entity<Spouse>().HasOne(i => i.Member).WithOne(s => s.Spouse);

            builder.Entity<Payment>().ToTable("Payment");
            builder.Entity<Payment>().Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Entity<Payment>().HasOne(m => m.Member).WithOne(p => p.Payments);

            builder.Entity<Mode>().ToTable("Mode");
            builder.Entity<Mode>().Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Entity<Referrer>().ToTable("Referrer");
            builder.Entity<Referrer>().Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Entity<Token>().ToTable("Token");
            builder.Entity<Token>().Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Entity<Token>().HasOne(i => i.User).WithMany(u => u.Tokens);

            builder.Entity<Location>().ToTable("Location");
            builder.Entity<Location>().Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Entity<Fee>().ToTable("Fee");
            builder.Entity<Fee>().Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Entity<Category>().ToTable("Category");
            builder.Entity<Category>().Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Entity<Cheque>().ToTable("Cheque");
            builder.Entity<Cheque>().Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Entity<Event>().ToTable("Event");
            builder.Entity<Event>().Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Entity<EventCategory>().ToTable("EventCategory");
            builder.Entity<EventCategory>().Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Entity<Speaker>().ToTable("Speaker");
            builder.Entity<Speaker>().Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Entity<Sponsor>().ToTable("Sponsor");
            builder.Entity<Sponsor>().Property(i => i.Id).ValueGeneratedOnAdd();

        }

        #region Properties
        public DbSet<Member> Members { get; set; }
        public DbSet<Spouse> Spouse { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Mode> Modes { get; set; }
        public DbSet<Referrer> Referrers { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cheque> Cheques { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }

        #endregion Properties
    }
}
