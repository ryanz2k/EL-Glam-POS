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
            // Use the same connection string you normally use in MauiProgram.cs
            optionsBuilder.UseSqlite("Filename=elglampos.db");
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
            
            // Decimal precision mapping
            modelBuilder.Entity<ServiceItem>().Property(s => s.BasePrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Transaction>().Property(t => t.TotalAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<TransactionItem>().Property(ti => ti.PriceAtTimeOfSale).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<TransactionItem>().Property(ti => ti.CalculatedCommission).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<CommissionRule>().Property(cr => cr.Percentage).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<CommissionRule>().Property(cr => cr.MinPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<CommissionRule>().Property(cr => cr.MaxPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Transaction>().Property(t => t.DiscountAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<DraftOrderItem>().Property(d => d.FinalPrice).HasColumnType("decimal(18,2)");

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
                new ServiceCategory { Id = 1, Name = "Facial Care" },
new ServiceCategory { Id = 2, Name = "Warts removal" },
new ServiceCategory { Id = 3, Name = "Eyelash Care - Lift" },
new ServiceCategory { Id = 4, Name = "Eyelash Care - Extensions" },
new ServiceCategory { Id = 5, Name = "Semi-Permanent Make Up" },
new ServiceCategory { Id = 6, Name = "Gluta Push & Drip" },
new ServiceCategory { Id = 7, Name = "Eyebrows Care" },
new ServiceCategory { Id = 8, Name = "Hair & Make Up" },
new ServiceCategory { Id = 9, Name = "Hair Care - Men" },
new ServiceCategory { Id = 10, Name = "Hair Care - Women" },
new ServiceCategory { Id = 11, Name = "Special Treatment" },
new ServiceCategory { Id = 12, Name = "Hair Color" },
new ServiceCategory { Id = 13, Name = "Rebonding" },
new ServiceCategory { Id = 14, Name = "Brazilian Treatment" },
new ServiceCategory { Id = 15, Name = "Combo" },
new ServiceCategory { Id = 16, Name = "Body Care" },
new ServiceCategory { Id = 17, Name = "Facial & Body Slimming" },
new ServiceCategory { Id = 18, Name = "Massage" },
new ServiceCategory { Id = 19, Name = "Nail Care - Regular Polish" },
new ServiceCategory { Id = 20, Name = "Nail Care - Imported Polish" },
new ServiceCategory { Id = 21, Name = "Nail Care - Gel Polish" },
new ServiceCategory { Id = 22, Name = "Nail Extensions" },
new ServiceCategory { Id = 23, Name = "Others" },
new ServiceCategory { Id = 24, Name = "Waxing/Threading" },
new ServiceCategory { Id = 25, Name = "Permanent Hair Removal" }
            );

            // Seed Service Items
            modelBuilder.Entity<ServiceItem>().HasData(
                new ServiceItem { Id = 1, Name = "Signature Facial", BasePrice = 399m, IsVariablePrice = false, CategoryId = 1, Type = ItemType.Service },
new ServiceItem { Id = 2, Name = "Facial with Diamond Peel", BasePrice = 499m, IsVariablePrice = false, CategoryId = 1, Type = ItemType.Service },
new ServiceItem { Id = 3, Name = "Facial Combo", BasePrice = 599m, IsVariablePrice = false, CategoryId = 1, Type = ItemType.Service },
new ServiceItem { Id = 4, Name = "Facial Botox", BasePrice = 699m, IsVariablePrice = false, CategoryId = 1, Type = ItemType.Service },
new ServiceItem { Id = 5, Name = "Acne Control Treatment", BasePrice = 899m, IsVariablePrice = false, CategoryId = 1, Type = ItemType.Service },
new ServiceItem { Id = 6, Name = "Backcial", BasePrice = 999m, IsVariablePrice = false, CategoryId = 1, Type = ItemType.Service },
new ServiceItem { Id = 7, Name = "Melasma Care Treatment", BasePrice = 2499m, IsVariablePrice = false, CategoryId = 1, Type = ItemType.Service },
new ServiceItem { Id = 8, Name = "Korean BB Glow", BasePrice = 1299m, IsVariablePrice = false, CategoryId = 1, Type = ItemType.Service },
new ServiceItem { Id = 9, Name = "Hydra-Facial Treatment", BasePrice = 999m, IsVariablePrice = false, CategoryId = 1, Type = ItemType.Service },
new ServiceItem { Id = 10, Name = "Carbon Laser Facial", BasePrice = 999m, IsVariablePrice = false, CategoryId = 1, Type = ItemType.Service },
new ServiceItem { Id = 11, Name = "Unlimited Face Area", BasePrice = 799m, IsVariablePrice = false, CategoryId = 2, Type = ItemType.Service },
new ServiceItem { Id = 12, Name = "Unlimited Neck Area", BasePrice = 799m, IsVariablePrice = false, CategoryId = 2, Type = ItemType.Service },
new ServiceItem { Id = 13, Name = "Unlimited Face & Neck Area", BasePrice = 1499m, IsVariablePrice = false, CategoryId = 2, Type = ItemType.Service },
new ServiceItem { Id = 14, Name = "Eyelash Lifting", BasePrice = 499m, IsVariablePrice = false, CategoryId = 3, Type = ItemType.Service },
new ServiceItem { Id = 15, Name = "Eyelash Lifting with Tint", BasePrice = 599m, IsVariablePrice = false, CategoryId = 3, Type = ItemType.Service },
new ServiceItem { Id = 16, Name = "Synthetic Eyelashes", BasePrice = 599m, IsVariablePrice = false, CategoryId = 4, Type = ItemType.Service },
new ServiceItem { Id = 17, Name = "Regular Human Hair", BasePrice = 799m, IsVariablePrice = false, CategoryId = 4, Type = ItemType.Service },
new ServiceItem { Id = 18, Name = "Ultrasoft Human Hair", BasePrice = 899m, IsVariablePrice = false, CategoryId = 4, Type = ItemType.Service },
new ServiceItem { Id = 19, Name = "Micro-Shading 1 Session", BasePrice = 2499m, IsVariablePrice = false, CategoryId = 5, Type = ItemType.Service },
new ServiceItem { Id = 20, Name = "Micro-Shading 2 Session", BasePrice = 3999m, IsVariablePrice = false, CategoryId = 5, Type = ItemType.Service },
new ServiceItem { Id = 21, Name = "Eyeliner 1 Session", BasePrice = 2499m, IsVariablePrice = false, CategoryId = 5, Type = ItemType.Service },
new ServiceItem { Id = 22, Name = "Eyeliner 2 Session", BasePrice = 3999m, IsVariablePrice = false, CategoryId = 5, Type = ItemType.Service },
new ServiceItem { Id = 23, Name = "Lip Tattoo 1 Session", BasePrice = 2499m, IsVariablePrice = false, CategoryId = 5, Type = ItemType.Service },
new ServiceItem { Id = 24, Name = "Lip Tattoo 2 Session", BasePrice = 3999m, IsVariablePrice = false, CategoryId = 5, Type = ItemType.Service },
new ServiceItem { Id = 25, Name = "Vitamin C Shot", BasePrice = 199m, IsVariablePrice = false, CategoryId = 6, Type = ItemType.Service },
new ServiceItem { Id = 26, Name = "Collagen Shot", BasePrice = 380m, IsVariablePrice = false, CategoryId = 6, Type = ItemType.Service },
new ServiceItem { Id = 27, Name = "Stem Cell", BasePrice = 380m, IsVariablePrice = false, CategoryId = 6, Type = ItemType.Service },
new ServiceItem { Id = 28, Name = "Gluta I.V. Push", BasePrice = 380m, IsVariablePrice = false, CategoryId = 6, Type = ItemType.Service },
new ServiceItem { Id = 29, Name = "Placenta", BasePrice = 499m, IsVariablePrice = false, CategoryId = 6, Type = ItemType.Service },
new ServiceItem { Id = 30, Name = "Glamorous White Shot", BasePrice = 599m, IsVariablePrice = false, CategoryId = 6, Type = ItemType.Service },
new ServiceItem { Id = 31, Name = "Express White Drip", BasePrice = 999m, IsVariablePrice = false, CategoryId = 6, Type = ItemType.Service },
new ServiceItem { Id = 32, Name = "Snow White Drip", BasePrice = 1699m, IsVariablePrice = false, CategoryId = 6, Type = ItemType.Service },
new ServiceItem { Id = 33, Name = "Cindella Drip", BasePrice = 1799m, IsVariablePrice = false, CategoryId = 6, Type = ItemType.Service },
new ServiceItem { Id = 34, Name = "Hikari Drip", BasePrice = 1799m, IsVariablePrice = false, CategoryId = 6, Type = ItemType.Service },
new ServiceItem { Id = 35, Name = "Brow Lamination", BasePrice = 399m, IsVariablePrice = false, CategoryId = 7, Type = ItemType.Service },
new ServiceItem { Id = 36, Name = "Brow Lamination with Tint", BasePrice = 449m, IsVariablePrice = false, CategoryId = 7, Type = ItemType.Service },
new ServiceItem { Id = 37, Name = "Hairdo/Styling", BasePrice = 500m, IsVariablePrice = false, CategoryId = 8, Type = ItemType.Service },
new ServiceItem { Id = 38, Name = "Make Up", BasePrice = 500m, IsVariablePrice = false, CategoryId = 8, Type = ItemType.Service },
new ServiceItem { Id = 39, Name = "Hair & Make Up", BasePrice = 800m, IsVariablePrice = false, CategoryId = 8, Type = ItemType.Service },
new ServiceItem { Id = 40, Name = "Haircut", BasePrice = 150m, IsVariablePrice = false, CategoryId = 9, Type = ItemType.Service },
new ServiceItem { Id = 41, Name = "Haircut with Shampoo", BasePrice = 250m, IsVariablePrice = false, CategoryId = 9, Type = ItemType.Service },
new ServiceItem { Id = 42, Name = "Haircut with Color", BasePrice = 1000m, IsVariablePrice = false, CategoryId = 9, Type = ItemType.Service },
new ServiceItem { Id = 43, Name = "Haircut", BasePrice = 250m, IsVariablePrice = false, CategoryId = 10, Type = ItemType.Service },
new ServiceItem { Id = 44, Name = "Haircut with Shampoo", BasePrice = 350m, IsVariablePrice = false, CategoryId = 10, Type = ItemType.Service },
new ServiceItem { Id = 45, Name = "Hair Iron/Blowdry", BasePrice = 350m, IsVariablePrice = false, CategoryId = 10, Type = ItemType.Service },
new ServiceItem { Id = 46, Name = "Loreal Power Dose", BasePrice = 1500m, IsVariablePrice = false, CategoryId = 11, Type = ItemType.Service },
new ServiceItem { Id = 47, Name = "Plarmia Scalp Treatment", BasePrice = 1500m, IsVariablePrice = false, CategoryId = 11, Type = ItemType.Service },
new ServiceItem { Id = 48, Name = "Grand Linkage", BasePrice = 2000m, IsVariablePrice = false, CategoryId = 11, Type = ItemType.Service },
new ServiceItem { Id = 49, Name = "Hair Cellophane", BasePrice = 800m, IsVariablePrice = false, CategoryId = 11, Type = ItemType.Service },
new ServiceItem { Id = 50, Name = "Hair Color with Treatment", BasePrice = 1500m, IsVariablePrice = true, CategoryId = 12, Type = ItemType.Service },
new ServiceItem { Id = 51, Name = "Hair Color/Highlights/Treatment", BasePrice = 2500m, IsVariablePrice = true, CategoryId = 12, Type = ItemType.Service },
new ServiceItem { Id = 52, Name = "Hair Balayage", BasePrice = 3000m, IsVariablePrice = true, CategoryId = 12, Type = ItemType.Service },
new ServiceItem { Id = 53, Name = "Regular Hair Rebond", BasePrice = 1500m, IsVariablePrice = true, CategoryId = 13, Type = ItemType.Service },
new ServiceItem { Id = 54, Name = "Premium Hair Rebond", BasePrice = 3000m, IsVariablePrice = true, CategoryId = 13, Type = ItemType.Service },
new ServiceItem { Id = 55, Name = "Brazilian Treatment", BasePrice = 1500m, IsVariablePrice = true, CategoryId = 14, Type = ItemType.Service },
new ServiceItem { Id = 56, Name = "Brazilian Treatment + Hair Color", BasePrice = 2500m, IsVariablePrice = true, CategoryId = 14, Type = ItemType.Service },
new ServiceItem { Id = 57, Name = "Brazilian Treatment + Hair Rebond", BasePrice = 2500m, IsVariablePrice = true, CategoryId = 14, Type = ItemType.Service },
new ServiceItem { Id = 58, Name = "Hair Color/Rebond/Brazilian", BasePrice = 3000m, IsVariablePrice = true, CategoryId = 15, Type = ItemType.Service },
new ServiceItem { Id = 59, Name = "Highlights/Color/Rebond/Brazilian", BasePrice = 3500m, IsVariablePrice = true, CategoryId = 15, Type = ItemType.Service },
new ServiceItem { Id = 60, Name = "Body Scrub & Whitening", BasePrice = 999m, IsVariablePrice = false, CategoryId = 16, Type = ItemType.Service },
new ServiceItem { Id = 61, Name = "Underarm Whitening", BasePrice = 499m, IsVariablePrice = false, CategoryId = 16, Type = ItemType.Service },
new ServiceItem { Id = 62, Name = "Underarm Premium Glow", BasePrice = 899m, IsVariablePrice = false, CategoryId = 16, Type = ItemType.Service },
new ServiceItem { Id = 63, Name = "Butt/Bikini Line Whitening", BasePrice = 599m, IsVariablePrice = false, CategoryId = 16, Type = ItemType.Service },
new ServiceItem { Id = 64, Name = "Bikini Premium Glow", BasePrice = 1199m, IsVariablePrice = false, CategoryId = 16, Type = ItemType.Service },
new ServiceItem { Id = 65, Name = "Elbows/Knees Whitening", BasePrice = 499m, IsVariablePrice = false, CategoryId = 16, Type = ItemType.Service },
new ServiceItem { Id = 66, Name = "RF Facial Contour", BasePrice = 349m, IsVariablePrice = false, CategoryId = 17, Type = ItemType.Service },
new ServiceItem { Id = 67, Name = "RF with Cavitation per area", BasePrice = 599m, IsVariablePrice = false, CategoryId = 17, Type = ItemType.Service },
new ServiceItem { Id = 68, Name = "RF Arms/Tummy/Back", BasePrice = 1499m, IsVariablePrice = false, CategoryId = 17, Type = ItemType.Service },
new ServiceItem { Id = 69, Name = "Mesotherapy with FREE RF per vial", BasePrice = 999m, IsVariablePrice = false, CategoryId = 17, Type = ItemType.Service },
new ServiceItem { Id = 70, Name = "Ultherapy Face Area", BasePrice = 3999m, IsVariablePrice = false, CategoryId = 17, Type = ItemType.Service },
new ServiceItem { Id = 71, Name = "Ultherapy other areas", BasePrice = 5999m, IsVariablePrice = false, CategoryId = 17, Type = ItemType.Service },
new ServiceItem { Id = 72, Name = "Trio Slim", BasePrice = 999m, IsVariablePrice = false, CategoryId = 17, Type = ItemType.Service },
new ServiceItem { Id = 73, Name = "Full Body Massage 60 Mins", BasePrice = 599m, IsVariablePrice = false, CategoryId = 18, Type = ItemType.Service },
new ServiceItem { Id = 74, Name = "Full Body Massage 30 Mins", BasePrice = 399m, IsVariablePrice = false, CategoryId = 18, Type = ItemType.Service },
new ServiceItem { Id = 75, Name = "Foot Massage 60 Mins", BasePrice = 349m, IsVariablePrice = false, CategoryId = 18, Type = ItemType.Service },
new ServiceItem { Id = 76, Name = "Foot Massage 30 Mins", BasePrice = 249m, IsVariablePrice = false, CategoryId = 18, Type = ItemType.Service },
new ServiceItem { Id = 77, Name = "Ventosa Cupping 60 Mins", BasePrice = 699m, IsVariablePrice = false, CategoryId = 18, Type = ItemType.Service },
new ServiceItem { Id = 78, Name = "Manicure", BasePrice = 150m, IsVariablePrice = false, CategoryId = 19, Type = ItemType.Service },
new ServiceItem { Id = 79, Name = "Pedicure with Soaking", BasePrice = 200m, IsVariablePrice = false, CategoryId = 19, Type = ItemType.Service },
new ServiceItem { Id = 80, Name = "Pedicure with Footspa", BasePrice = 450m, IsVariablePrice = false, CategoryId = 19, Type = ItemType.Service },
new ServiceItem { Id = 81, Name = "Manicure", BasePrice = 230m, IsVariablePrice = false, CategoryId = 20, Type = ItemType.Service },
new ServiceItem { Id = 82, Name = "Pedicure with Soaking", BasePrice = 300m, IsVariablePrice = false, CategoryId = 20, Type = ItemType.Service },
new ServiceItem { Id = 83, Name = "Pedicure with Footspa", BasePrice = 550m, IsVariablePrice = false, CategoryId = 20, Type = ItemType.Service },
new ServiceItem { Id = 84, Name = "Manicure", BasePrice = 550m, IsVariablePrice = false, CategoryId = 21, Type = ItemType.Service },
new ServiceItem { Id = 85, Name = "Pedicure with Soaking", BasePrice = 600m, IsVariablePrice = false, CategoryId = 21, Type = ItemType.Service },
new ServiceItem { Id = 86, Name = "Pedicure with Footspa", BasePrice = 750m, IsVariablePrice = false, CategoryId = 21, Type = ItemType.Service },
new ServiceItem { Id = 87, Name = "Foot Spa Alone", BasePrice = 350m, IsVariablePrice = false, CategoryId = 21, Type = ItemType.Service },
new ServiceItem { Id = 88, Name = "Imported Extensions", BasePrice = 1599m, IsVariablePrice = false, CategoryId = 22, Type = ItemType.Service },
new ServiceItem { Id = 89, Name = "Soft Gel Extensions", BasePrice = 1299m, IsVariablePrice = false, CategoryId = 22, Type = ItemType.Service },
new ServiceItem { Id = 90, Name = "Additional Nail Art", BasePrice = 350m, IsVariablePrice = false, CategoryId = 23, Type = ItemType.Service },
new ServiceItem { Id = 91, Name = "Stones", BasePrice = 10m, IsVariablePrice = false, CategoryId = 23, Type = ItemType.Service },
new ServiceItem { Id = 92, Name = "Eyebrows Threading", BasePrice = 120m, IsVariablePrice = false, CategoryId = 24, Type = ItemType.Service },
new ServiceItem { Id = 93, Name = "Eyebrows Waxing", BasePrice = 149m, IsVariablePrice = false, CategoryId = 24, Type = ItemType.Service },
new ServiceItem { Id = 94, Name = "Upper Mouth", BasePrice = 149m, IsVariablePrice = false, CategoryId = 24, Type = ItemType.Service },
new ServiceItem { Id = 95, Name = "Lower Mouth", BasePrice = 149m, IsVariablePrice = false, CategoryId = 24, Type = ItemType.Service },
new ServiceItem { Id = 96, Name = "Underarms", BasePrice = 199m, IsVariablePrice = false, CategoryId = 24, Type = ItemType.Service },
new ServiceItem { Id = 97, Name = "Brazilian/Bikini Line", BasePrice = 699m, IsVariablePrice = false, CategoryId = 24, Type = ItemType.Service },
new ServiceItem { Id = 98, Name = "Arms - Women", BasePrice = 299m, IsVariablePrice = true, CategoryId = 24, Type = ItemType.Service },
new ServiceItem { Id = 99, Name = "Legs - Women", BasePrice = 499m, IsVariablePrice = true, CategoryId = 24, Type = ItemType.Service },
new ServiceItem { Id = 100, Name = "Underarm Hair Removal", BasePrice = 699m, IsVariablePrice = false, CategoryId = 25, Type = ItemType.Service },
new ServiceItem { Id = 101, Name = "Underarm Whitening", BasePrice = 699m, IsVariablePrice = false, CategoryId = 25, Type = ItemType.Service },
new ServiceItem { Id = 102, Name = "Underarm Removal & Whitening", BasePrice = 1099m, IsVariablePrice = false, CategoryId = 25, Type = ItemType.Service },
new ServiceItem { Id = 103, Name = "Lower/Upper Mouth", BasePrice = 399m, IsVariablePrice = false, CategoryId = 25, Type = ItemType.Service },
new ServiceItem { Id = 104, Name = "Lower & Upper Mouth Combo", BasePrice = 599m, IsVariablePrice = false, CategoryId = 25, Type = ItemType.Service },
new ServiceItem { Id = 105, Name = "Arms", BasePrice = 399m, IsVariablePrice = true, CategoryId = 25, Type = ItemType.Service },
new ServiceItem { Id = 106, Name = "Legs", BasePrice = 599m, IsVariablePrice = true, CategoryId = 25, Type = ItemType.Service },
new ServiceItem { Id = 107, Name = "Brazilian/Bikini Line", BasePrice = 999m, IsVariablePrice = false, CategoryId = 25, Type = ItemType.Service },
new ServiceItem { Id = 108, Name = "Pigmentation Laser", BasePrice = 899m, IsVariablePrice = false, CategoryId = 25, Type = ItemType.Service },
new ServiceItem { Id = 109, Name = "Acne/Skin Rejuvenating Laser", BasePrice = 899m, IsVariablePrice = false, CategoryId = 25, Type = ItemType.Service }
            );

        }
    }
}
