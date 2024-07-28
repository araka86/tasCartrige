using System.Data.Entity;

namespace CartrigeAltstar.Model
{
    public class ContexAltstar : DbContext
    {

        public ContexAltstar() : base("DefaultConnection")
        {
            Database.SetInitializer(new ContexAltstarInit());
        }  //initialization 1

        //static ContexAltstar()
        //{
        //    Database.SetInitializer(new ContexAltstarInit());
        //}

        
        public DbSet<Compatibility> Compatibilities { get; set; } //Совместимость
        public DbSet<Printer> Printers { get; set; } //Принтеры
        public DbSet<Department> Departments { get; set; } //Подразделения
        public DbSet<Cartrige> Cartriges { get; set; } //Картриджи
        public DbSet<Cartrigelolocation> Cartrigelolocations { get; set; } //Прием картриджей

        public DbSet<CountCartige> CountCartiges { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CartrigeModel> CartrigeModels { get; set; }
        public DbSet<CartrigePurchase> CartrigePurchases { get; set; }
        public DbSet<CartrigeIssue> CartrigeIssues { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {




            modelBuilder.Entity<Cartrige>()
                           .HasMany(c => c.CountCartiges)
                           .WithRequired(cc => cc.Cartrige)
                           .HasForeignKey(cc => cc.CartrigeId);

            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<CartrigeModel>()
        .HasKey(cm => cm.Id);

            modelBuilder.Entity<CartrigePurchase>()
                .HasKey(cp => cp.Id);

            modelBuilder.Entity<CartrigeIssue>()
                .HasKey(ci => ci.Id);

            modelBuilder.Entity<CartrigePurchase>()
                .HasRequired(cp => cp.CartrigeModel)
                .WithMany(cm => cm.CartrigePurchases)
                .HasForeignKey(cp => cp.ModelId);

            modelBuilder.Entity<CartrigeIssue>()
                .HasRequired(ci => ci.CartrigeModel)
                .WithMany(cm => cm.CartrigeIssues)
                .HasForeignKey(ci => ci.ModelId);

            base.OnModelCreating(modelBuilder);



            //modelBuilder.Entity<Compatibility>()
            //    .HasRequired(c => c.CartrigePK)
            //    .WithMany(x => x.Compatibilitys)
            //    .HasForeignKey(c => c.CartrigeId)
            //    .WillCascadeOnDelete(false);




            //modelBuilder.Entity<Printer>()
            //    .HasOptional(p => p.CartrigePk)
            //    .WithMany(a => a.Printers)                // Добавляем это, чтобы указать свойство обратной навигации (2 стрелочки)
            //    .HasForeignKey(p => p.CartrigeId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Login>().HasData(
            //    new Login 
            //{
            //    Id = 1,
            //    Name = "Test",
            //    Password = "password",
            //});

        }


        // .Net Core
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //        optionsBuilder.UseSqlServer(connectionString, options =>
        //        {
        //            //   options.EnableRetryOnFailure(); // Включаем повторные попытки при сбоях
        //        });
        //    }
        //}




        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Cartrige>()
        //   .HasOne(c => c.Article)
        //   .WithMany(a => a.Cartriges)
        //   .HasForeignKey(c => c.ArticleId)
        //   .OnDelete(DeleteBehavior.SetNull);
        //}






    }


}
