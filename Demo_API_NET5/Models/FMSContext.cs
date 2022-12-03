using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Demo_API_NET5.Models
{
    public partial class FMSContext : DbContext
    {
        public FMSContext()
        {
        }

        public FMSContext(DbContextOptions<FMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Counter> Counters { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<IdentityCard> IdentityCards { get; set; }
        public virtual DbSet<IdentityCard1> IdentityCards1 { get; set; }
        public virtual DbSet<MoneyTransaction> MoneyTransactions { get; set; }
        public virtual DbSet<MoneyTransaction1> MoneyTransactions1 { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<TransactionShared> TransactionShareds { get; set; }
        public virtual DbSet<TransactionShared1> TransactionShareds1 { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=FMS;User ID=sa;Password=12345;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.HasIndex(e => e.Username, "UQ__Account__536C85E44071C533")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Account__RoleID__2B3F6F97");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Counter>(entity =>
            {
                entity.ToTable("Counter");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.DoB).HasColumnType("date");

                entity.Property(e => e.Gender).HasDefaultValueSql("((2))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Phone).HasMaxLength(12);
            });

            modelBuilder.Entity<IdentityCard>(entity =>
            {
                entity.ToTable("identity_card");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<IdentityCard1>(entity =>
            {
                entity.ToTable("IdentityCard");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.IdentityCard1s)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__IdentityC__Custo__4CA06362");
            });

            modelBuilder.Entity<MoneyTransaction>(entity =>
            {
                entity.ToTable("money_transaction");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(19, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.Counterid).HasColumnName("counterid");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date");

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Method)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("method");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Walletid).HasColumnName("walletid");
            });

            modelBuilder.Entity<MoneyTransaction1>(entity =>
            {
                entity.ToTable("MoneyTransaction");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.CounterId).HasColumnName("CounterID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Method)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('Cash')");

                entity.Property(e => e.WalletId).HasColumnName("WalletID");

                entity.HasOne(d => d.Counter)
                    .WithMany(p => p.MoneyTransaction1s)
                    .HasForeignKey(d => d.CounterId)
                    .HasConstraintName("FK__MoneyTran__Count__59FA5E80");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.MoneyTransaction1s)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__MoneyTran__Custo__571DF1D5");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.Total).HasColumnType("decimal(19, 4)");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Orders__StoreID__37A5467C");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProId })
                    .HasName("PK_OrderDetails");

                entity.ToTable("OrderDetail");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProId)
                    .HasMaxLength(20)
                    .HasColumnName("ProID");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(30, 4)")
                    .HasComputedColumnSql("([Price]*[Quantity])", false);

                entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderDeta__Order__3C69FB99");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__ProID__3D5E1FD2");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Payment__OrderID__4222D4EF");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasColumnName("ID");

                entity.Property(e => e.CateId).HasColumnName("CateID");

                entity.Property(e => e.ImagePath).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.HasOne(d => d.Cate)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CateId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Product__CateID__32E0915F");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Product__StoreID__33D4B598");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Store__AccountID__2F10007B");
            });

            modelBuilder.Entity<TransactionShared>(entity =>
            {
                entity.ToTable("transaction_shared");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("numeric(19, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasColumnName("created_date");

                entity.Property(e => e.HashValue)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("hash_value");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.MoneyTransactionid).HasColumnName("money_transactionid");

                entity.Property(e => e.Paymentid).HasColumnName("paymentid");

                entity.Property(e => e.PreviousBalance)
                    .HasColumnType("numeric(19, 2)")
                    .HasColumnName("previous_balance");

                entity.Property(e => e.PreviousHash)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("previous_hash");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Walletid).HasColumnName("walletid");
            });

            modelBuilder.Entity<TransactionShared1>(entity =>
            {
                entity.ToTable("TransactionShared");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.HashValue)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.MoneyTransactionId).HasColumnName("MoneyTransactionID");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.PreviousBalance).HasColumnType("decimal(19, 4)");

                entity.Property(e => e.PreviousHash)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Status).HasDefaultValueSql("((0))");

                entity.Property(e => e.WalletId).HasColumnName("WalletID");

                entity.HasOne(d => d.MoneyTransaction)
                    .WithMany(p => p.TransactionShared1s)
                    .HasForeignKey(d => d.MoneyTransactionId)
                    .HasConstraintName("FK__Transacti__Money__6383C8BA");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.TransactionShared1s)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK__Transacti__Payme__6477ECF3");

                entity.HasOne(d => d.Wallet)
                    .WithMany(p => p.TransactionShared1s)
                    .HasForeignKey(d => d.WalletId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Walle__60A75C0F");
            });

            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.ToTable("Wallet");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Wallets)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Wallet__Customer__5070F446");
            });

            modelBuilder.HasSequence("hibernate_sequence");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
