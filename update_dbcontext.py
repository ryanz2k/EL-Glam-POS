import re
import subprocess

# Run the seed generator to get the categories and services
result = subprocess.run(['python', 'seed_generator.py'], capture_output=True, text=True)
output = result.stdout

categories_part = output.split("Categories:\n")[1].split("\nServices:\n")[0].strip()
services_part = output.split("\nServices:\n")[1].strip()

# Read the PosDbContext.cs
with open('Data/PosDbContext.cs', 'r', encoding='utf-8') as f:
    content = f.read()

# Make changes to the content
content = content.replace("using Microsoft.EntityFrameworkCore;", "using Microsoft.EntityFrameworkCore;\nusing Microsoft.AspNetCore.Identity.EntityFrameworkCore;")
content = content.replace("public class PosDbContext : DbContext", "public class PosDbContext : IdentityDbContext<ApplicationUser>")

content = content.replace("public DbSet<ServiceItem> ServiceItems { get; set; } = null!;", "public DbSet<ServiceCategory> ServiceCategories { get; set; } = null!;\n        public DbSet<ServiceItem> ServiceItems { get; set; } = null!;")

content = content.replace("modelBuilder.Entity<ServiceItem>().Property(s => s.Price)", "modelBuilder.Entity<ServiceItem>().Property(s => s.BasePrice)")

# Create the user seed block
# Actually we can't use passlib easily here, so we will use PasswordHasher in C# logic or just leave PasswordHash as a known hash.
# Alternatively, I can generate a pre-hashed string for "password123".
# In Identity, PasswordHash uses PBKDF2 with HMAC-SHA256, 128-bit salt, 256-bit subkey, 10000 iterations.
# A simpler way is to just set PasswordHash to a precomputed hash for "password123".
# "AQAAAAIAAYagAAAAEP0v+y5..." Let's just use a dummy hash or no hash and configure it later, but Identity requires a valid hash.
# Let's use a standard known hash for "password123" using default ASP.NET Core V3 hasher.
known_hash = "AQAAAAIAAYagAAAAEOc73tVvOXZWJgE20hVn87vBq3J0b8tK8BXZy3g==" # just a placeholder, but will cause login failure if not exact.
# Wait, it's better to let a small C# script run to hash the password or let the seed method use PasswordHasher.
# In OnModelCreating we can do:
hasher_code = """
            var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<ApplicationUser>();
            var users = new List<ApplicationUser>
            {
                new ApplicationUser { Id = "1", UserName = "jesa@salon.com", NormalizedUserName = "JESA@SALON.COM", Email = "jesa@salon.com", NormalizedEmail = "JESA@SALON.COM", EmployeeId = 1 },
                new ApplicationUser { Id = "2", UserName = "marilyn@salon.com", NormalizedUserName = "MARILYN@SALON.COM", Email = "marilyn@salon.com", NormalizedEmail = "MARILYN@SALON.COM", EmployeeId = 7 },
                new ApplicationUser { Id = "3", UserName = "rowena@salon.com", NormalizedUserName = "ROWENA@SALON.COM", Email = "rowena@salon.com", NormalizedEmail = "ROWENA@SALON.COM", EmployeeId = 13 },
                new ApplicationUser { Id = "4", UserName = "jennifer@salon.com", NormalizedUserName = "JENNIFER@SALON.COM", Email = "jennifer@salon.com", NormalizedEmail = "JENNIFER@SALON.COM", EmployeeId = 16 }
            };

            foreach (var u in users) { u.PasswordHash = hasher.HashPassword(u, "password123"); }
            
            modelBuilder.Entity<ApplicationUser>().HasData(users);
"""

# Replace the ServiceItem seed block
old_seed_block = r"// Update Seed Data for Service Items to have types and categories\s+modelBuilder\.Entity<ServiceItem>\(\)\.HasData\([\s\S]*?\);"

new_seed_block = f"""
            // Seed Application Users
{hasher_code}

            // Seed Service Categories
            modelBuilder.Entity<ServiceCategory>().HasData(
                {categories_part}
            );

            // Seed Service Items
            modelBuilder.Entity<ServiceItem>().HasData(
                {services_part}
            );
"""

content = re.sub(old_seed_block, new_seed_block, content)

with open('Data/PosDbContext.cs', 'w', encoding='utf-8') as f:
    f.write(content)

print("Updated PosDbContext.cs successfully.")
