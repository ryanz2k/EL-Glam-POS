using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ELGlamPOS.Models;

using Microsoft.EntityFrameworkCore.Design;

namespace ELGlamPOS.Data
{
    public class PosDbContextFactory : IDesignTimeDbContextFactory<PosDbContext>
    {
        public PosDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PosDbContext>();
            optionsBuilder.UseSqlite("Filename=pos_v3.db");
            return new PosDbContext(optionsBuilder.Options);
        }
    }

    public class PosDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ServiceCategory> ServiceCategories { get; set; } = null!;
        public DbSet<ServiceItem> ServiceItems { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;
        public DbSet<TransactionItem> TransactionItems { get; set; } = null!;
        
        public DbSet<Branch> Branches { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<CommissionRule> CommissionRules { get; set; } = null!;
        public DbSet<DraftOrder> DraftOrders { get; set; } = null!;
        public DbSet<DraftOrderItem> DraftOrderItems { get; set; } = null!;
        public DbSet<DailyReport> DailyReports { get; set; } = null!;

        public PosDbContext(DbContextOptions<PosDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ── Decimal precision ──────────────────────────────────────────────────
            modelBuilder.Entity<ServiceItem>().Property(s => s.BasePrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Transaction>().Property(t => t.TotalAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Transaction>().Property(t => t.DiscountAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Transaction>().Property(t => t.CashAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Transaction>().Property(t => t.GCashAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Transaction>().Property(t => t.MayaAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Transaction>().Property(t => t.BankTransferAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<TransactionItem>().Property(ti => ti.PriceAtTimeOfSale).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<TransactionItem>().Property(ti => ti.CalculatedCommission).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<CommissionRule>().Property(cr => cr.Percentage).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<CommissionRule>().Property(cr => cr.MinPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<CommissionRule>().Property(cr => cr.MaxPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<DraftOrderItem>().Property(d => d.FinalPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<DailyReport>().Property(r => r.CashAdvance).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<DailyReport>().Property(r => r.Expenses).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<DailyReport>().Property(r => r.PullOut).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<DailyReport>().Property(r => r.OpeningCashOnHand).HasColumnType("decimal(18,2)");

            // ── Firebase sync columns ──────────────────────────────────────────────
            modelBuilder.Entity<Transaction>().Property(t => t.FirebaseKey).HasColumnName("FirebaseKey");
            modelBuilder.Entity<Transaction>().Property(t => t.SyncStatus).HasColumnName("SyncStatus");
            modelBuilder.Entity<Transaction>().Property(t => t.LastSyncedAt).HasColumnName("LastSyncedAt");
            modelBuilder.Entity<Transaction>().Property(t => t.SourceAppointmentKey).HasColumnName("SourceAppointmentKey");
            modelBuilder.Entity<DailyReport>().Property(r => r.FirebaseKey).HasColumnName("FirebaseKey");
            modelBuilder.Entity<DailyReport>().Property(r => r.SyncStatus).HasColumnName("SyncStatus");
            modelBuilder.Entity<DailyReport>().Property(r => r.LastSyncedAt).HasColumnName("LastSyncedAt");
            modelBuilder.Entity<DailyReport>().Property(r => r.SubmittedAt).HasColumnName("SubmittedAt");
            modelBuilder.Entity<Employee>().Property(e => e.FirebaseNameKey).HasColumnName("FirebaseNameKey");
            modelBuilder.Entity<DraftOrder>().Property(d => d.SourceAppointmentKey).HasColumnName("SourceAppointmentKey");

            // DraftOrder relationships
            modelBuilder.Entity<DraftOrder>()
                .HasOne(d => d.CreatedByEmployee)
                .WithMany()
                .HasForeignKey(d => d.CreatedByEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relationships
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Receptionist)
                .WithMany()
                .HasForeignKey(t => t.ReceptionistId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TransactionItem>()
                .HasOne(ti => ti.AssignedEmployee)
                .WithMany()
                .HasForeignKey(ti => ti.AssignedEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed Branches
            modelBuilder.Entity<Branch>().HasData(
                new Branch { Id = 1, Name = "Mandaue" },
                new Branch { Id = 2, Name = "Pajac" },
                new Branch { Id = 3, Name = "Pusok" },
                new Branch { Id = 4, Name = "Cebu" }
            );

            // Seed Employees
            modelBuilder.Entity<Employee>().HasData(
                // Mandaue
                new Employee { Id = 1, Name = "Jesa Mae Basi", Role = EmployeeRole.Receptionist, JobTitle = "Receptionist", BranchId = 1 },
                new Employee { Id = 2, Name = "Sanny Grace Yekla", Role = EmployeeRole.ServiceProvider, JobTitle = "Facialist", BranchId = 1 },
                new Employee { Id = 3, Name = "Rosegina Davis", Role = EmployeeRole.ServiceProvider, JobTitle = "Nail Technician", BranchId = 1 },
                new Employee { Id = 4, Name = "Ruthamie Momo", Role = EmployeeRole.ServiceProvider, JobTitle = "Facialist", BranchId = 1 },
                new Employee { Id = 5, Name = "Imae Rose Dela Torre", Role = EmployeeRole.ServiceProvider, JobTitle = "Nail Technician", BranchId = 1 },
                new Employee { Id = 6, Name = "Jennipher Yaon", Role = EmployeeRole.ServiceProvider, JobTitle = "Hair Stylist", BranchId = 1 },
                // Pajac
                new Employee { Id = 7, Name = "Marilyn Teves", Role = EmployeeRole.Receptionist, JobTitle = "Receptionist", BranchId = 2 },
                new Employee { Id = 8, Name = "Mattlaine Clyrr Belarmino", Role = EmployeeRole.ServiceProvider, JobTitle = "Facialist", BranchId = 2 },
                new Employee { Id = 9, Name = "Jenalyn Entig", Role = EmployeeRole.ServiceProvider, JobTitle = "Nail Technician", BranchId = 2 },
                new Employee { Id = 10, Name = "Buenafe Arnado", Role = EmployeeRole.ServiceProvider, JobTitle = "Hair Stylist/Nail Tech", BranchId = 2 },
                new Employee { Id = 11, Name = "Elvira Omac", Role = EmployeeRole.ServiceProvider, JobTitle = "Hair Stylist/Nail Tech", BranchId = 2 },
                new Employee { Id = 12, Name = "Keyn Joshua Demane", Role = EmployeeRole.ServiceProvider, JobTitle = "Barber", BranchId = 2 },
                // Pusok
                new Employee { Id = 13, Name = "Rowena Pedor", Role = EmployeeRole.ServiceProvider, JobTitle = "Nail Technician", BranchId = 3 },
                new Employee { Id = 14, Name = "Julie Ann Abadajos", Role = EmployeeRole.ServiceProvider, JobTitle = "Facialist", BranchId = 3 },
                new Employee { Id = 15, Name = "Janeth Dimco", Role = EmployeeRole.ServiceProvider, JobTitle = "Hair Stylist", BranchId = 3 },
                // Cebu
                new Employee { Id = 16, Name = "Jennifer Cabreles", Role = EmployeeRole.ServiceProvider, JobTitle = "Nail Technician", BranchId = 4 },
                new Employee { Id = 17, Name = "Jessica Macatanong", Role = EmployeeRole.ServiceProvider, JobTitle = "Nail Technician", BranchId = 4 },
                new Employee { Id = 18, Name = "Rubelyn Cañizares", Role = EmployeeRole.ServiceProvider, JobTitle = "Facialist", BranchId = 4 },
                new Employee { Id = 19, Name = "Jeanny Dela Torre", Role = EmployeeRole.ServiceProvider, JobTitle = "Facialist", BranchId = 4 },
                new Employee { Id = 20, Name = "Lucille Tailo", Role = EmployeeRole.ServiceProvider, JobTitle = "Hair Stylist", BranchId = 4 },
                // Admin
                new Employee { Id = 21, Name = "Admin", Role = EmployeeRole.Admin, JobTitle = "Administrator", BranchId = 1 }
            );

            // Seed Commission Rules
            var rules = new List<CommissionRule>();
            int ruleId = 1;

            // Helper for creating rules
            CommissionRule CreateRule(int empId, decimal pct, ItemType? targetItemType = null, string? targetCat = null, decimal? minPrice = null, decimal? maxPrice = null, int prio = 0)
            {
                return new CommissionRule { Id = ruleId++, EmployeeId = empId, Percentage = pct, TargetItemType = targetItemType, TargetCategory = targetCat, MinPrice = minPrice, MaxPrice = maxPrice, Priority = prio };
            }

            // Sanny Grace Yekla (Id: 2)
            rules.Add(CreateRule(2, 40m, ItemType.Service, "Massage", prio: 10));
            rules.Add(CreateRule(2, 10m, ItemType.Service, "Injectables", prio: 10));
            rules.Add(CreateRule(2, 10m, ItemType.Product, prio: 5));

            // Rosegina Davis (Id: 3)
            rules.Add(CreateRule(3, 5m, ItemType.Service, prio: 1)); // general services
            rules.Add(CreateRule(3, 40m, ItemType.Service, "Massage", prio: 10));
            rules.Add(CreateRule(3, 10m, ItemType.Product, prio: 5));
            rules.Add(CreateRule(3, 8m, ItemType.Service, "Hair", prio: 10));

            // Ruthamie Momo (Id: 4)
            rules.Add(CreateRule(4, 5m, ItemType.Service, prio: 1));
            rules.Add(CreateRule(4, 10m, null, prio: 2)); // 10% on all services and products (overrides 5%)

            // Imae Rose Dela Torre (Id: 5)
            rules.Add(CreateRule(5, 5m, null, prio: 1)); // 5% all services & products

            // Jennipher Yaon (Id: 6)
            rules.Add(CreateRule(6, 10m, null, prio: 1)); // 10% all services & products

            // Mattlaine Clyrr Belarmino (Id: 8)
            rules.Add(CreateRule(8, 20m, ItemType.Service, "Microshading", prio: 10));
            rules.Add(CreateRule(8, 10m, ItemType.Product, prio: 5));
            rules.Add(CreateRule(8, 8m, ItemType.Service, minPrice: 1000m, prio: 5)); // 8% services above 1000

            // Jenalyn Entig (Id: 9)
            rules.Add(CreateRule(9, 5m, ItemType.Service, maxPrice: 998.99m, prio: 1)); // 5% services below 999
            rules.Add(CreateRule(9, 10m, ItemType.Product, prio: 5));
            rules.Add(CreateRule(9, 10m, ItemType.Service, minPrice: 499m, prio: 10)); // 10% major services above 499
            rules.Add(CreateRule(9, 5m, ItemType.Service, prio: 2)); // 5% minor services (acts as default service if no min/max applied)

            // Buenafe Arnado (Id: 10)
            rules.Add(CreateRule(10, 10m, null, prio: 1)); // 10% all services and products

            // Elvira Omac (Id: 11)
            rules.Add(CreateRule(11, 10m, null, prio: 1)); // 10% all services and products

            // Keyn Joshua Demape (Id: 12)
            rules.Add(CreateRule(12, 50m, ItemType.Service, prio: 1)); // 50% all services

            // Rowena Pedor (Id: 13)
            rules.Add(CreateRule(13, 10m, ItemType.Product, prio: 5));
            rules.Add(CreateRule(13, 5m, ItemType.Service, prio: 1)); // 5% minor services
            rules.Add(CreateRule(13, 10m, ItemType.Service, minPrice: 499m, prio: 10)); // 10% major services above 499

            // Julie Ann Abadajos (Id: 14)
            rules.Add(CreateRule(14, 10m, ItemType.Product, prio: 5));
            rules.Add(CreateRule(14, 5m, ItemType.Service, prio: 1)); // 5% services

            // Janeth Dimco (Id: 15)
            rules.Add(CreateRule(15, 10m, null, prio: 1)); // 10% all services and products

            // Jennifer Cabreles (Id: 16)
            rules.Add(CreateRule(16, 5m, null, prio: 1)); // 5% all services and products

            // Jessica Macatanong (Id: 17)
            rules.Add(CreateRule(17, 5m, ItemType.Service, prio: 1));
            rules.Add(CreateRule(17, 10m, ItemType.Product, prio: 5)); // 10% products

            // Rubelyn Cañizares (Id: 18)
            rules.Add(CreateRule(18, 10m, ItemType.Service, "Massage", prio: 10));
            rules.Add(CreateRule(18, 5m, ItemType.Service, prio: 1)); // 5% services

            // Jeanny Dela Torre (Id: 19)
            rules.Add(CreateRule(19, 10m, ItemType.Service, "Massage", prio: 10));
            rules.Add(CreateRule(19, 5m, ItemType.Service, prio: 1)); // 5% services

            // Lucille Tailo (Id: 20)
            rules.Add(CreateRule(20, 5m, null, prio: 1)); // 5% all services and products

            modelBuilder.Entity<CommissionRule>().HasData(rules);

            
            // Seed Application Users

            var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<ApplicationUser>();
            var users = new List<ApplicationUser>
            {
                new ApplicationUser { Id = "1", UserName = "jesa@salon.com", NormalizedUserName = "JESA@SALON.COM", Email = "jesa@salon.com", NormalizedEmail = "JESA@SALON.COM", EmployeeId = 1 },
                new ApplicationUser { Id = "2", UserName = "marilyn@salon.com", NormalizedUserName = "MARILYN@SALON.COM", Email = "marilyn@salon.com", NormalizedEmail = "MARILYN@SALON.COM", EmployeeId = 7 },
                new ApplicationUser { Id = "3", UserName = "rowena@salon.com", NormalizedUserName = "ROWENA@SALON.COM", Email = "rowena@salon.com", NormalizedEmail = "ROWENA@SALON.COM", EmployeeId = 13 },
                new ApplicationUser { Id = "4", UserName = "jennifer@salon.com", NormalizedUserName = "JENNIFER@SALON.COM", Email = "jennifer@salon.com", NormalizedEmail = "JENNIFER@SALON.COM", EmployeeId = 16 },
                new ApplicationUser { Id = "5", UserName = "admin@salon.com", NormalizedUserName = "ADMIN@SALON.COM", Email = "admin@salon.com", NormalizedEmail = "ADMIN@SALON.COM", EmployeeId = 21 }
            };

            foreach (var u in users) { u.PasswordHash = hasher.HashPassword(u, "password123"); }
            
            modelBuilder.Entity<ApplicationUser>().HasData(users);


                                                // Seed Service Categories
            modelBuilder.Entity<ServiceCategory>().HasData(
                new ServiceCategory { Id = 50, Name = "Facial Care", Area = "Clinic" },
                new ServiceCategory { Id = 51, Name = "Warts Removal", Area = "Clinic" },
                new ServiceCategory { Id = 52, Name = "Gluta Push & Drip", Area = "Clinic" },
                new ServiceCategory { Id = 53, Name = "Eyelash & Brows Care", Area = "Clinic" },
                new ServiceCategory { Id = 54, Name = "Semi-Permanent Make Up", Area = "Clinic" },
                new ServiceCategory { Id = 55, Name = "Others (Hair & Make Up)", Area = "Salon" },
                new ServiceCategory { Id = 56, Name = "Hair Removal", Area = "Clinic" },
                new ServiceCategory { Id = 57, Name = "IPL/Diode Laser Treatment", Area = "Clinic" },
                new ServiceCategory { Id = 58, Name = "Body Care", Area = "Clinic" },
                new ServiceCategory { Id = 59, Name = "Facial & Body Slimming", Area = "Clinic" },
                new ServiceCategory { Id = 60, Name = "Massage", Area = "Clinic" },
                new ServiceCategory { Id = 61, Name = "Nail Care", Area = "Salon" },
                new ServiceCategory { Id = 62, Name = "Hair Care", Area = "Salon" }
            );

            // Seed Service Items
            modelBuilder.Entity<ServiceItem>().HasData(
                new ServiceItem { Id = 200, Name = "Signature Facial", BasePrice = 399.0m, IsVariablePrice = false, CategoryId = 50, Type = ItemType.Service },
                new ServiceItem { Id = 201, Name = "Facial with Diamond Peel", BasePrice = 549.0m, IsVariablePrice = false, CategoryId = 50, Type = ItemType.Service },
                new ServiceItem { Id = 202, Name = "Facial Botox", BasePrice = 699.0m, IsVariablePrice = false, CategoryId = 50, Type = ItemType.Service },
                new ServiceItem { Id = 203, Name = "Full Glow Combo", BasePrice = 799.0m, IsVariablePrice = false, CategoryId = 50, Type = ItemType.Service },
                new ServiceItem { Id = 204, Name = "Acne Control Treatment", BasePrice = 799.0m, IsVariablePrice = false, CategoryId = 50, Type = ItemType.Service },
                new ServiceItem { Id = 205, Name = "Backcial", BasePrice = 999.0m, IsVariablePrice = false, CategoryId = 50, Type = ItemType.Service },
                new ServiceItem { Id = 206, Name = "Korean BB Glow", BasePrice = 1299.0m, IsVariablePrice = false, CategoryId = 50, Type = ItemType.Service },
                new ServiceItem { Id = 207, Name = "Hydra-Facial Treatment", BasePrice = 1499.0m, IsVariablePrice = false, CategoryId = 50, Type = ItemType.Service },
                new ServiceItem { Id = 208, Name = "Carbon Laser Facial", BasePrice = 1499.0m, IsVariablePrice = false, CategoryId = 50, Type = ItemType.Service },
                new ServiceItem { Id = 209, Name = "Melasma Care Treatment (Micro-Needling)", BasePrice = 2499.0m, IsVariablePrice = false, CategoryId = 50, Type = ItemType.Service },
                new ServiceItem { Id = 210, Name = "Unlimited Face Area", BasePrice = 799.0m, IsVariablePrice = false, CategoryId = 51, Type = ItemType.Service },
                new ServiceItem { Id = 211, Name = "Unlimited Neck Area", BasePrice = 799.0m, IsVariablePrice = false, CategoryId = 51, Type = ItemType.Service },
                new ServiceItem { Id = 212, Name = "Unlimited Face & Neck Area", BasePrice = 1499.0m, IsVariablePrice = false, CategoryId = 51, Type = ItemType.Service },
                new ServiceItem { Id = 213, Name = "Vitamin C Shot", BasePrice = 299.0m, IsVariablePrice = false, CategoryId = 52, Type = ItemType.Service },
                new ServiceItem { Id = 214, Name = "Gluta IV Push", BasePrice = 399.0m, IsVariablePrice = false, CategoryId = 52, Type = ItemType.Service },
                new ServiceItem { Id = 215, Name = "Collagen Shot", BasePrice = 499.0m, IsVariablePrice = false, CategoryId = 52, Type = ItemType.Service },
                new ServiceItem { Id = 216, Name = "Stem Cell", BasePrice = 499.0m, IsVariablePrice = false, CategoryId = 52, Type = ItemType.Service },
                new ServiceItem { Id = 217, Name = "Placenta", BasePrice = 499.0m, IsVariablePrice = false, CategoryId = 52, Type = ItemType.Service },
                new ServiceItem { Id = 218, Name = "Glamorous White Shot", BasePrice = 599.0m, IsVariablePrice = false, CategoryId = 52, Type = ItemType.Service },
                new ServiceItem { Id = 219, Name = "Express White Drip", BasePrice = 999.0m, IsVariablePrice = false, CategoryId = 52, Type = ItemType.Service },
                new ServiceItem { Id = 220, Name = "Snow White Drip", BasePrice = 1799.0m, IsVariablePrice = false, CategoryId = 52, Type = ItemType.Service },
                new ServiceItem { Id = 221, Name = "Cindella Drip", BasePrice = 1899.0m, IsVariablePrice = false, CategoryId = 52, Type = ItemType.Service },
                new ServiceItem { Id = 222, Name = "Hikari Drip", BasePrice = 1899.0m, IsVariablePrice = false, CategoryId = 52, Type = ItemType.Service },
                new ServiceItem { Id = 223, Name = "Eyelash Lift", BasePrice = 499.0m, IsVariablePrice = false, CategoryId = 53, Type = ItemType.Service },
                new ServiceItem { Id = 224, Name = "Eyelash Lift with Tint", BasePrice = 599.0m, IsVariablePrice = false, CategoryId = 53, Type = ItemType.Service },
                new ServiceItem { Id = 225, Name = "Synthetic Eyelash Extensions", BasePrice = 599.0m, IsVariablePrice = false, CategoryId = 53, Type = ItemType.Service },
                new ServiceItem { Id = 226, Name = "Regular Human Hair Eyelash Extensions", BasePrice = 799.0m, IsVariablePrice = false, CategoryId = 53, Type = ItemType.Service },
                new ServiceItem { Id = 227, Name = "Ultrasoft Human Hair Eyelash Extensions", BasePrice = 899.0m, IsVariablePrice = false, CategoryId = 53, Type = ItemType.Service },
                new ServiceItem { Id = 228, Name = "Eyelash Extensions Removal", BasePrice = 300.0m, IsVariablePrice = false, CategoryId = 53, Type = ItemType.Service },
                new ServiceItem { Id = 229, Name = "Eyelash Extensions Retouch", BasePrice = 250.0m, IsVariablePrice = true, CategoryId = 53, Type = ItemType.Service },
                new ServiceItem { Id = 230, Name = "Brow Lamination", BasePrice = 499.0m, IsVariablePrice = false, CategoryId = 53, Type = ItemType.Service },
                new ServiceItem { Id = 231, Name = "Brow Lamination with tint", BasePrice = 599.0m, IsVariablePrice = false, CategoryId = 53, Type = ItemType.Service },
                new ServiceItem { Id = 232, Name = "Eyebrow Micro-Shading (1 Session)", BasePrice = 2999.0m, IsVariablePrice = false, CategoryId = 54, Type = ItemType.Service },
                new ServiceItem { Id = 233, Name = "Eyebrow Micro-Shading (2 Sessions)", BasePrice = 4499.0m, IsVariablePrice = false, CategoryId = 54, Type = ItemType.Service },
                new ServiceItem { Id = 234, Name = "Lips Blush (1 Session)", BasePrice = 2999.0m, IsVariablePrice = false, CategoryId = 54, Type = ItemType.Service },
                new ServiceItem { Id = 235, Name = "Lips Blush (2 Sessions)", BasePrice = 4499.0m, IsVariablePrice = false, CategoryId = 54, Type = ItemType.Service },
                new ServiceItem { Id = 236, Name = "Eyeliner (1 Session)", BasePrice = 2499.0m, IsVariablePrice = false, CategoryId = 54, Type = ItemType.Service },
                new ServiceItem { Id = 237, Name = "Eyeliner (2 Sessions)", BasePrice = 3999.0m, IsVariablePrice = false, CategoryId = 54, Type = ItemType.Service },
                new ServiceItem { Id = 238, Name = "Hairdo/Styling", BasePrice = 600.0m, IsVariablePrice = false, CategoryId = 55, Type = ItemType.Service },
                new ServiceItem { Id = 239, Name = "Make Up", BasePrice = 600.0m, IsVariablePrice = false, CategoryId = 55, Type = ItemType.Service },
                new ServiceItem { Id = 240, Name = "Hair & Make Up", BasePrice = 1000.0m, IsVariablePrice = false, CategoryId = 55, Type = ItemType.Service },
                new ServiceItem { Id = 241, Name = "Eyebrows Threading", BasePrice = 149.0m, IsVariablePrice = false, CategoryId = 56, Type = ItemType.Service },
                new ServiceItem { Id = 242, Name = "Eyebrows Waxing", BasePrice = 149.0m, IsVariablePrice = false, CategoryId = 56, Type = ItemType.Service },
                new ServiceItem { Id = 243, Name = "Upper Mouth", BasePrice = 149.0m, IsVariablePrice = false, CategoryId = 56, Type = ItemType.Service },
                new ServiceItem { Id = 244, Name = "Lower Mouth", BasePrice = 149.0m, IsVariablePrice = false, CategoryId = 56, Type = ItemType.Service },
                new ServiceItem { Id = 245, Name = "Underarms", BasePrice = 249.0m, IsVariablePrice = false, CategoryId = 56, Type = ItemType.Service },
                new ServiceItem { Id = 246, Name = "Brazilian/Bikini Line", BasePrice = 799.0m, IsVariablePrice = false, CategoryId = 56, Type = ItemType.Service },
                new ServiceItem { Id = 247, Name = "Arms (Women)", BasePrice = 299.0m, IsVariablePrice = true, CategoryId = 56, Type = ItemType.Service },
                new ServiceItem { Id = 248, Name = "Legs (Women)", BasePrice = 499.0m, IsVariablePrice = true, CategoryId = 56, Type = ItemType.Service },
                new ServiceItem { Id = 249, Name = "Arms (Men)", BasePrice = 399.0m, IsVariablePrice = true, CategoryId = 56, Type = ItemType.Service },
                new ServiceItem { Id = 250, Name = "Legs (Men)", BasePrice = 599.0m, IsVariablePrice = true, CategoryId = 56, Type = ItemType.Service },
                new ServiceItem { Id = 251, Name = "Underarm Hair Removal", BasePrice = 699.0m, IsVariablePrice = false, CategoryId = 57, Type = ItemType.Service },
                new ServiceItem { Id = 252, Name = "Underarm Whitening", BasePrice = 699.0m, IsVariablePrice = false, CategoryId = 57, Type = ItemType.Service },
                new ServiceItem { Id = 253, Name = "Underarm Hair Removal & Whitening Combo", BasePrice = 1099.0m, IsVariablePrice = false, CategoryId = 57, Type = ItemType.Service },
                new ServiceItem { Id = 254, Name = "Lower/Upper Mouth Hair Removal", BasePrice = 399.0m, IsVariablePrice = false, CategoryId = 57, Type = ItemType.Service },
                new ServiceItem { Id = 255, Name = "Lower & Upper Mouth Combo Hair Removal", BasePrice = 599.0m, IsVariablePrice = false, CategoryId = 57, Type = ItemType.Service },
                new ServiceItem { Id = 256, Name = "Arms Hair Removal", BasePrice = 399.0m, IsVariablePrice = true, CategoryId = 57, Type = ItemType.Service },
                new ServiceItem { Id = 257, Name = "Legs Hair Removal", BasePrice = 599.0m, IsVariablePrice = true, CategoryId = 57, Type = ItemType.Service },
                new ServiceItem { Id = 258, Name = "Brazilian/Bikini Line Hair Removal", BasePrice = 999.0m, IsVariablePrice = false, CategoryId = 57, Type = ItemType.Service },
                new ServiceItem { Id = 259, Name = "Pigmentation Laser", BasePrice = 899.0m, IsVariablePrice = false, CategoryId = 57, Type = ItemType.Service },
                new ServiceItem { Id = 260, Name = "Skin Rejuvenating Laser", BasePrice = 899.0m, IsVariablePrice = false, CategoryId = 57, Type = ItemType.Service },
                new ServiceItem { Id = 261, Name = "Body Scrub & Whitening", BasePrice = 999.0m, IsVariablePrice = false, CategoryId = 58, Type = ItemType.Service },
                new ServiceItem { Id = 262, Name = "Underarm Whitening (With Diamond Peel)", BasePrice = 499.0m, IsVariablePrice = false, CategoryId = 58, Type = ItemType.Service },
                new ServiceItem { Id = 263, Name = "Underarm Premium Glow", BasePrice = 899.0m, IsVariablePrice = false, CategoryId = 58, Type = ItemType.Service },
                new ServiceItem { Id = 264, Name = "Butt/Bikini Line Whitening", BasePrice = 599.0m, IsVariablePrice = false, CategoryId = 58, Type = ItemType.Service },
                new ServiceItem { Id = 265, Name = "Bikini Premium Glow", BasePrice = 1199.0m, IsVariablePrice = false, CategoryId = 58, Type = ItemType.Service },
                new ServiceItem { Id = 266, Name = "Elbows Whitening", BasePrice = 499.0m, IsVariablePrice = false, CategoryId = 58, Type = ItemType.Service },
                new ServiceItem { Id = 267, Name = "Knees Whitening", BasePrice = 499.0m, IsVariablePrice = false, CategoryId = 58, Type = ItemType.Service },
                new ServiceItem { Id = 268, Name = "RF Facial Contour", BasePrice = 499.0m, IsVariablePrice = false, CategoryId = 59, Type = ItemType.Service },
                new ServiceItem { Id = 269, Name = "RF with Cavitation (per area)", BasePrice = 599.0m, IsVariablePrice = false, CategoryId = 59, Type = ItemType.Service },
                new ServiceItem { Id = 270, Name = "RF Arms, Tummy, & Back", BasePrice = 1599.0m, IsVariablePrice = false, CategoryId = 59, Type = ItemType.Service },
                new ServiceItem { Id = 271, Name = "Trio Slim Treatment Mesotherapy with FREE RF (per vial)", BasePrice = 999.0m, IsVariablePrice = false, CategoryId = 59, Type = ItemType.Service },
                new ServiceItem { Id = 272, Name = "Slim Boost Therapy with FREE RF (per vial)", BasePrice = 2499.0m, IsVariablePrice = false, CategoryId = 59, Type = ItemType.Service },
                new ServiceItem { Id = 273, Name = "Ultherapy (Face Area)", BasePrice = 4999.0m, IsVariablePrice = false, CategoryId = 59, Type = ItemType.Service },
                new ServiceItem { Id = 274, Name = "Ultherapy (other areas)", BasePrice = 6999.0m, IsVariablePrice = false, CategoryId = 59, Type = ItemType.Service },
                new ServiceItem { Id = 275, Name = "Full Body Massage (60mins)", BasePrice = 599.0m, IsVariablePrice = false, CategoryId = 60, Type = ItemType.Service },
                new ServiceItem { Id = 276, Name = "Full Body Massage (30mins)", BasePrice = 399.0m, IsVariablePrice = false, CategoryId = 60, Type = ItemType.Service },
                new ServiceItem { Id = 277, Name = "Foot Massage (60mins)", BasePrice = 349.0m, IsVariablePrice = false, CategoryId = 60, Type = ItemType.Service },
                new ServiceItem { Id = 278, Name = "Foot Massage (30mins)", BasePrice = 249.0m, IsVariablePrice = false, CategoryId = 60, Type = ItemType.Service },
                new ServiceItem { Id = 279, Name = "Ventosa Cupping (60mins)", BasePrice = 699.0m, IsVariablePrice = false, CategoryId = 60, Type = ItemType.Service },
                new ServiceItem { Id = 280, Name = "Regular Polish - Manicure", BasePrice = 150.0m, IsVariablePrice = false, CategoryId = 61, Type = ItemType.Service },
                new ServiceItem { Id = 281, Name = "Regular Polish - Pedicure with Soaking", BasePrice = 200.0m, IsVariablePrice = false, CategoryId = 61, Type = ItemType.Service },
                new ServiceItem { Id = 282, Name = "Regular Polish - Pedicure with Footspa", BasePrice = 450.0m, IsVariablePrice = false, CategoryId = 61, Type = ItemType.Service },
                new ServiceItem { Id = 283, Name = "Imported Polish - Manicure", BasePrice = 230.0m, IsVariablePrice = false, CategoryId = 61, Type = ItemType.Service },
                new ServiceItem { Id = 284, Name = "Imported Polish - Pedicure with Soaking", BasePrice = 300.0m, IsVariablePrice = false, CategoryId = 61, Type = ItemType.Service },
                new ServiceItem { Id = 285, Name = "Imported Polish - Pedicure with Footspa", BasePrice = 550.0m, IsVariablePrice = false, CategoryId = 61, Type = ItemType.Service },
                new ServiceItem { Id = 286, Name = "Gel Polish - Manicure", BasePrice = 550.0m, IsVariablePrice = false, CategoryId = 61, Type = ItemType.Service },
                new ServiceItem { Id = 287, Name = "Gel Polish - Pedicure with Soaking", BasePrice = 600.0m, IsVariablePrice = false, CategoryId = 61, Type = ItemType.Service },
                new ServiceItem { Id = 288, Name = "Gel Polish - Pedicure with Footspa", BasePrice = 750.0m, IsVariablePrice = false, CategoryId = 61, Type = ItemType.Service },
                new ServiceItem { Id = 289, Name = "Nail Extensions - Imported Extensions plain gel polish", BasePrice = 1599.0m, IsVariablePrice = false, CategoryId = 61, Type = ItemType.Service },
                new ServiceItem { Id = 290, Name = "Nail Extensions - Soft Gel Extensions plain gel polish", BasePrice = 1299.0m, IsVariablePrice = false, CategoryId = 61, Type = ItemType.Service },
                new ServiceItem { Id = 291, Name = "Others - Foot Spa", BasePrice = 350.0m, IsVariablePrice = false, CategoryId = 61, Type = ItemType.Service },
                new ServiceItem { Id = 292, Name = "Others - Ingrown Removal", BasePrice = 30.0m, IsVariablePrice = false, CategoryId = 61, Type = ItemType.Service },
                new ServiceItem { Id = 293, Name = "Others - Additional Nail Art", BasePrice = 350.0m, IsVariablePrice = true, CategoryId = 61, Type = ItemType.Service },
                new ServiceItem { Id = 294, Name = "Others - Stones", BasePrice = 10.0m, IsVariablePrice = true, CategoryId = 61, Type = ItemType.Service },
                new ServiceItem { Id = 295, Name = "Men - Haircut", BasePrice = 200.0m, IsVariablePrice = false, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 296, Name = "Men - Haircut with Shampoo", BasePrice = 300.0m, IsVariablePrice = false, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 297, Name = "Men - Hair Color with Cut", BasePrice = 1000.0m, IsVariablePrice = false, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 298, Name = "Men - Hair Perming", BasePrice = 1000.0m, IsVariablePrice = false, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 299, Name = "Women - Haircut", BasePrice = 250.0m, IsVariablePrice = false, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 300, Name = "Women - Haircut with Shampoo", BasePrice = 350.0m, IsVariablePrice = false, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 301, Name = "Women - Hair Iron", BasePrice = 350.0m, IsVariablePrice = false, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 302, Name = "Women - Hair Blowdry", BasePrice = 350.0m, IsVariablePrice = false, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 303, Name = "Women - Hair Perming", BasePrice = 1500.0m, IsVariablePrice = false, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 304, Name = "Special Treatment - Loreal Hair Spa", BasePrice = 1500.0m, IsVariablePrice = true, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 305, Name = "Special Treatment - Plarmia Scalp Treatment", BasePrice = 1500.0m, IsVariablePrice = true, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 306, Name = "Special Treatment - Grand Linkage Damage Repair", BasePrice = 2000.0m, IsVariablePrice = true, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 307, Name = "Special Treatment - Hair Cellophane", BasePrice = 800.0m, IsVariablePrice = true, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 308, Name = "Special Treatment - Protein Straight Bond", BasePrice = 2500.0m, IsVariablePrice = true, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 309, Name = "Hair Color - Hair Color & Treatment", BasePrice = 1500.0m, IsVariablePrice = true, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 310, Name = "Hair Color - Hair Color, Highlights & Treatment", BasePrice = 2500.0m, IsVariablePrice = true, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 311, Name = "Hair Color - Hair Balayage", BasePrice = 3000.0m, IsVariablePrice = true, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 312, Name = "Rebonding - Regular Hair Rebond", BasePrice = 1500.0m, IsVariablePrice = true, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 313, Name = "Rebonding - Premium Hair Rebond", BasePrice = 3000.0m, IsVariablePrice = true, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 314, Name = "Brazilian Treatment - Brazilian Treatment", BasePrice = 1500.0m, IsVariablePrice = true, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 315, Name = "Beauty Combo - Hair Color, Rebond", BasePrice = 2500.0m, IsVariablePrice = true, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 316, Name = "Beauty Combo - Hair Color, Brazilian", BasePrice = 2500.0m, IsVariablePrice = true, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 317, Name = "Beauty Combo - Hair Color, Rebond, Brazilian Treatment", BasePrice = 3000.0m, IsVariablePrice = true, CategoryId = 62, Type = ItemType.Service },
                new ServiceItem { Id = 318, Name = "Beauty Combo - Hair Color, Highlights, Rebond, Brazilian Treatment", BasePrice = 3500.0m, IsVariablePrice = true, CategoryId = 62, Type = ItemType.Service }
            );
}
    }
}
