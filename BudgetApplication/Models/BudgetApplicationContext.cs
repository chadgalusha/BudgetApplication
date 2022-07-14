using Microsoft.EntityFrameworkCore;

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
        public virtual DbSet<EstimatedIncomeAmount> EstimatedIncomeAmounts { get; set; } = null!;
        public virtual DbSet<EstimatedIncomeToIncome> EstimatedIncomeToIncomes { get; set; } = null!;
        public virtual DbSet<Incomes> Incomes { get; set; } = null!;
        public virtual DbSet<IncomeHistory> IncomeHistories { get; set; } = null!;
        public virtual DbSet<IncomeTypes> IncomeTypes { get; set; } = null!;
        public virtual DbSet<PaymentFrequencyTypes> PaymentFrequencyTypes { get; set; } = null!;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstimatedIncomeToIncome>()
                .HasKey(k => new { k.EstimatedIncomeId, k.IncomeId } );
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
