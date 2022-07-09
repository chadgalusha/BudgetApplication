using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BudgetApplication.Models
{
    public partial class BudgetApplicationContext : DbContext
    {
        public BudgetApplicationContext()
        {
        }

        public BudgetApplicationContext(DbContextOptions<BudgetApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BankAccountTypes> BankAccountTypes { get; set; } = null!;
        public virtual DbSet<BankAccounts> BankAccounts { get; set; } = null!;
        public virtual DbSet<PaymentFrequencies> PaymentFrequencies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=galusha-xps\\sqlexpress;Initial Catalog=BudgetApplication;Integrated Security=True");
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<BankAccountTypes>(entity =>
        //    {
        //        entity.Property(e => e.BankAccountType1)
        //            .HasMaxLength(50)
        //            .IsUnicode(false)
        //            .HasColumnName("BankAccountType");
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
