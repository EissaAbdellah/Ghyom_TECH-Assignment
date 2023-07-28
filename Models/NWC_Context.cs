using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GhyomAssignment.Models
{
    public class NWC_Context:DbContext
    {


        private readonly IConfiguration configuration;

        public NWC_Context(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConn"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<NWC_Subscriber_File>()
                .HasMany(d => d.NWC_Subscription_Files)
                .WithOne(c => c.NWC_Subscriber_File)
                .HasForeignKey(c => c.NWC_Subscription_File_Subscriber_Code)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<NWC_Rreal_Estate_Types>()
               .HasMany(d => d.NWC_Subscription_Files)
               .WithOne(c => c.NWC_Rreal_Estate_Types)
               .HasForeignKey(c => c.NWC_Subscription_File_Rreal_Estate_Types_Code)
               .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<NWC_Subscriber_File>()
               .HasMany(d => d.NWC_Invoices)
               .WithOne(c => c.NWC_Subscriber_File)
               .HasForeignKey(c => c.NWC_Invoices_Subscriber_No)
               .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<NWC_Rreal_Estate_Types>()
              .HasMany(d => d.NWC_Invoices)
              .WithOne(c => c.NWC_Rreal_Estate_Types)
              .HasForeignKey(c => c.NWC_Invoices_Rreal_Estate_Types_No)
              .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<NWC_Subscription_File>()
              .HasMany(d => d.NWC_Invoices)
              .WithOne(c => c.NWC_Subscription_File)
              .HasForeignKey(c => c.NWC_Invoices_Subscription_No)
              .OnDelete(DeleteBehavior.Restrict);






            base.OnModelCreating(modelBuilder);
        }



        public DbSet<NWC_Rreal_Estate_Types> NWC_Rreal_Estate_Types { get; set; }

        public DbSet<NWC_Subscriber_File> NWC_Subscriber_Files { get; set; }
        
        public DbSet<NWC_Subscription_File> NWC_Subscription_Files { get; set; }

        public DbSet<NWC_Default_Slice_Values> NWC_Default_Slice_Values { get; set; }

        public DbSet<NWC_Invoices> NWC_Invoices { get; set; }





    }
}
