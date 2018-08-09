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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<ApplicationUser>().HasMany(u => u.Tokens).WithOne(i => i.User);

            builder.Entity<Member>().ToTable("Members");
            builder.Entity<Member>().Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Entity<Member>().HasMany(d => d.Dependents).WithOne(m => m.Member);

            builder.Entity<Dependent>().ToTable("Dependents");
            builder.Entity<Dependent>().Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Entity<Dependent>().HasOne(m => m.Member).WithMany(d => d.Dependents);

            builder.Entity<Spouse>().ToTable("Spouse");
            builder.Entity<Spouse>().Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Entity<Spouse>().HasOne(i => i.Member).WithOne(s => s.Spouse);

            builder.Entity<PaymentDetails>().ToTable("Payments");
            builder.Entity<PaymentDetails>().Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Entity<PaymentDetails>().HasOne(m => m.Member).WithOne(p => p.Payment);

            builder.Entity<PaymentMode>().ToTable("PaymentMode");
            builder.Entity<PaymentMode>().Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Entity<Referrer>().ToTable("Referrer");
            builder.Entity<Referrer>().Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Entity<Token>().ToTable("Tokens");
            builder.Entity<Token>().Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Entity<Token>().HasOne(i => i.User).WithMany(u => u.Tokens);

            builder.Entity<Location>().ToTable("Locations");
            builder.Entity<Location>().Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Entity<MembershipFee>().ToTable("MembershipFees");
            builder.Entity<MembershipFee>().Property(i => i.Id).ValueGeneratedOnAdd();
        }

        #region Properties
        public DbSet<Member> Members { get; set; }
        public DbSet<Spouse> Spouse { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<PaymentDetails> Payments { get; set; }
        public DbSet<PaymentMode> PaymentModes { get; set; }
        public DbSet<Referrer> Referrers { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<MembershipFee> MembershipFees { get; set; }
        #endregion Properties
    }
}
