using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class RajoDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<ContactInfo> ContactInfos { get; set; } = null!;
        public DbSet<ContactType> ContactTypes { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Manufacturer> Manufacturers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderRow> OrderRows { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<ShippingAlternative> ShippingAlternatives { get; set; } = null!;
        public DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;
        public DbSet<ShoppingCartRow> ShoppingCartRows { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserAddress> UserAddresses { get; set; } = null!;
        public DbSet<PaymentAlternative> PaymentAlternatives { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RajosDB;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RajoDbContext).Assembly);
            modelBuilder.UseCollation("Finnish_Swedish_CI_AS");

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Öl" },
                new Category { Id = 2, Name = "Vin" },
                new Category { Id = 3, Name = "Sprit" },
                new Category { Id = 4, Name = "Cider" },
                new Category { Id = 5, Name = "HB" }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Sverige" },
                new Country { Id = 2, Name = "Tjeckien" },
                new Country { Id = 3, Name = "USA" },
                new Country { Id = 4, Name = "Tyskland" },
                new Country { Id = 5, Name = "Italien" },
                new Country { Id = 6, Name = "Frankrike" }
            );

            modelBuilder.Entity<Manufacturer>().HasData(

                // Sverige
                new Manufacturer { Id = 1, Name = "Spendrups", CountryId = 1 },
                new Manufacturer { Id = 2, Name = "Carlsberg Sverige", CountryId = 1 },

                // Tjeckien
                new Manufacturer { Id = 3, Name = "Pilsner Urquell", CountryId = 2 },
                new Manufacturer { Id = 4, Name = "Budvar", CountryId = 2 },

                // USA
                new Manufacturer { Id = 5, Name = "Budweiser", CountryId = 3 },
                new Manufacturer { Id = 6, Name = "Coors", CountryId = 3 },

                // Tyskland
                new Manufacturer { Id = 7, Name = "Paulaner", CountryId = 4 },
                new Manufacturer { Id = 8, Name = "Becks", CountryId = 4 },

                // Italien
                new Manufacturer { Id = 9, Name = "Peroni", CountryId = 5 },
                new Manufacturer { Id = 10, Name = "Moretti", CountryId = 5 },

                // Frankrike
                new Manufacturer { Id = 11, Name = "Kronenbourg", CountryId = 6 },
                new Manufacturer { Id = 12, Name = "1664 Blanc", CountryId = 6 }
            );

            modelBuilder.Entity<Product>().HasData(

                // Öl (3 showcase totalt)
                new Product { Id = 1, Name = "Spendrups Bright Lager", Price = 22, Description = "Svensk ljus lager.", Stock = 15, Showcase = true, VatRate = 0.25m, CategoryId = 1, ManufacturerId = 1 },
                new Product { Id = 2, Name = "Carlsberg Export", Price = 23, Description = "Klassisk exportlager.", Stock = 18, Showcase = false, VatRate = 0.25m, CategoryId = 1, ManufacturerId = 2 },
                new Product { Id = 3, Name = "Pilsner Urquell Original", Price = 26, Description = "Tjeckisk pilsner.", Stock = 16, Showcase = true, VatRate = 0.25m, CategoryId = 1, ManufacturerId = 3 },
                new Product { Id = 4, Name = "Budvar Original", Price = 25, Description = "Maltig lager.", Stock = 14, Showcase = false, VatRate = 0.25m, CategoryId = 1, ManufacturerId = 4 },
                new Product { Id = 5, Name = "Budweiser Lager", Price = 22, Description = "Amerikansk lager.", Stock = 20, Showcase = false, VatRate = 0.25m, CategoryId = 1, ManufacturerId = 5 },
                new Product { Id = 6, Name = "Paulaner Weissbier", Price = 28, Description = "Tysk veteöl.", Stock = 12, Showcase = true, VatRate = 0.25m, CategoryId = 1, ManufacturerId = 7 },

                // Vin
                new Product { Id = 7, Name = "Chianti Classico", Price = 119, Description = "Italienskt rödvin.", Stock = 10, Showcase = false, VatRate = 0.25m, CategoryId = 2, ManufacturerId = 9 },
                new Product { Id = 8, Name = "Pinot Grigio", Price = 99, Description = "Friskt vitt vin.", Stock = 11, Showcase = false, VatRate = 0.25m, CategoryId = 2, ManufacturerId = 10 },
                new Product { Id = 9, Name = "Bordeaux Rouge", Price = 149, Description = "Franskt kvalitetsvin.", Stock = 8, Showcase = false, VatRate = 0.25m, CategoryId = 2, ManufacturerId = 11 },

                // Sprit
                new Product { Id = 10, Name = "Vodka Premium", Price = 249, Description = "Ren vodka.", Stock = 7, Showcase = false, VatRate = 0.25m, CategoryId = 3, ManufacturerId = 1 },
                new Product { Id = 11, Name = "Whiskey Reserve", Price = 329, Description = "Lagrad whiskey.", Stock = 5, Showcase = false, VatRate = 0.25m, CategoryId = 3, ManufacturerId = 5 },

                // Cider
                new Product { Id = 12, Name = "Somersby Pear", Price = 24, Description = "Päroncider.", Stock = 18, Showcase = false, VatRate = 0.25m, CategoryId = 4, ManufacturerId = 2 },
                new Product { Id = 13, Name = "Apple Dry Cider", Price = 26, Description = "Torr äppelcider.", Stock = 14, Showcase = false, VatRate = 0.25m, CategoryId = 4, ManufacturerId = 6 },

                // HB
                new Product { Id = 14, Name = "HB Stark Special", Price = 189, Description = "Hemblandad specialdryck.", Stock = 3, Showcase = false, VatRate = 0.25m, CategoryId = 5, ManufacturerId = 1 },
                new Product { Id = 15, Name = "HB Classic", Price = 169, Description = "Traditionell HB.", Stock = 4, Showcase = false, VatRate = 0.25m, CategoryId = 5, ManufacturerId = 3 }
            );

            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, Street = "Äskebacka", StreetNumber = "125", ZipCode = "451 95", City = "Uddevalla", CountryId = 1},
                new Address { Id = 2, Street = "Helenedalsvägen", StreetNumber = "16", ZipCode = "451 45", City = "Uddevalla", CountryId = 1 },
                new Address { Id = 3, Street = "Kunsgatan", StreetNumber = "22", ZipCode = "451 30", City = "Uddevalla", CountryId = 1 },
                new Address { Id = 4, Street = "Stenhammarsvägen", StreetNumber = "61", ZipCode = "531 56", City = "Lidköping", CountryId = 1 }

            );

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Kund" },
                new Role { Id = 2, Name = "Administratör" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Admin", UserName = "admin", CreatedAt = new DateTime(2026, 1, 1), RoleId = 2 },
                new User { Id = 2, Name = "Olle", UserName = "olle", CreatedAt = new DateTime(2026, 1, 1), RoleId = 1 },
                new User { Id = 3, Name = "Ruhollah", UserName = "ruhollah", CreatedAt = new DateTime(2026, 1, 1), RoleId = 1 },
                new User { Id = 4, Name = "Aron", UserName = "aron", CreatedAt = new DateTime(2026, 1, 1), RoleId = 1 },
                new User { Id = 5, Name = "Jimmy", UserName = "jimmy", CreatedAt = new DateTime(2026, 1, 1), RoleId = 1 }
                );

            modelBuilder.Entity<UserAddress>().HasData(
                new UserAddress { Id = 1, UserId = 2, AddressId = 1 },
                new UserAddress { Id = 2, UserId = 3, AddressId = 3 },
                new UserAddress { Id = 3, UserId = 4, AddressId = 4 },
                new UserAddress { Id = 4, UserId = 5, AddressId = 2 }
                );

            modelBuilder.Entity<ContactType>().HasData(
                new ContactType { Id = 1, Name = "Telefonnummer"},
                new ContactType { Id = 2, Name = "Epost" }
                );

            modelBuilder.Entity<ContactInfo>().HasData(
                new ContactInfo { Id = 1, Value = "0743905120", ContactTypeId = 1, UserId = 5 },
                new ContactInfo { Id = 2, Value = "eliassmmy76@gmail.com", ContactTypeId = 2, UserId = 5 },
                new ContactInfo { Id = 3, Value = "0765968445", ContactTypeId = 1, UserId = 4 },
                new ContactInfo { Id = 4, Value = "arosater@gmail.com", ContactTypeId = 2, UserId = 4 },
                new ContactInfo { Id = 5, Value = "0713159305", ContactTypeId = 1, UserId = 3 },
                new ContactInfo { Id = 6, Value = "ruhollahkari@gmail.com", ContactTypeId = 2, UserId = 3 },
                new ContactInfo { Id = 7, Value = "0123414142", ContactTypeId = 1, UserId = 2 },
                new ContactInfo { Id = 8, Value = "olle@olle.se", ContactTypeId = 2, UserId = 2 }
                );

            modelBuilder.Entity<ShoppingCart>().HasData(
                new ShoppingCart { Id = 1, Name = "Jimmys kundvagn", UserId = 5 },
                new ShoppingCart { Id = 2, Name = "Arons kundvagn", UserId = 4 },
                new ShoppingCart { Id = 3, Name = "Ruhollahs kundvagn", UserId = 3 },
                new ShoppingCart { Id = 4, Name = "Olles kundvagn", UserId = 2 }
                );

            modelBuilder.Entity<ShoppingCartRow>().HasData(
                new ShoppingCartRow { Id = 1, Quantity = 3, ProductId = 2, ShoppingCartId = 1 },
                new ShoppingCartRow { Id = 2, Quantity = 2, ProductId = 4, ShoppingCartId = 1 },
                new ShoppingCartRow { Id = 3, Quantity = 5, ProductId = 3, ShoppingCartId = 2 },
                new ShoppingCartRow { Id = 4, Quantity = 2, ProductId = 12, ShoppingCartId = 2 },
                new ShoppingCartRow { Id = 5, Quantity = 2, ProductId = 11, ShoppingCartId = 3 },
                new ShoppingCartRow { Id = 6, Quantity = 4, ProductId = 14, ShoppingCartId = 3 },
                new ShoppingCartRow { Id = 7, Quantity = 3, ProductId = 7, ShoppingCartId = 4 },
                new ShoppingCartRow { Id = 8, Quantity = 5, ProductId = 9, ShoppingCartId = 4 }
                );

            modelBuilder.Entity<ShippingAlternative>().HasData(
                new ShippingAlternative { Id = 1, Name = "DHL", Price = 49.00m},
                new ShippingAlternative { Id = 2, Name = "PostNord", Price = 89.00m}
                );

            modelBuilder.Entity<PaymentAlternative>().HasData(
                new PaymentAlternative { Id = 1, Name = "Faktura", Fee = 29.00m},
                new PaymentAlternative { Id = 2, Name = "Kortbetalning", Fee = 0.00m }
                );

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, Status = "Mottagen", ShippingAlternativeId = 1, UserId = 5, AddressId = 2, PaymentAlternativeId = 2 },
                new Order { Id = 2, Status = "Mottagen", ShippingAlternativeId = 2, UserId = 4, AddressId = 4, PaymentAlternativeId = 1 },
                new Order { Id = 3, Status = "Mottagen", ShippingAlternativeId = 1, UserId = 3, AddressId = 3, PaymentAlternativeId = 2 },
                new Order { Id = 4, Status = "Mottagen", ShippingAlternativeId = 2, UserId = 2, AddressId = 1, PaymentAlternativeId = 1 }
                );

            modelBuilder.Entity<OrderRow>().HasData(
                new OrderRow { Id = 1, Quantity = 1, ProductId = 3, OrderId = 1 },
                new OrderRow { Id = 2, Quantity = 13, ProductId = 6, OrderId = 1 },
                new OrderRow { Id = 3, Quantity = 3, ProductId = 14, OrderId = 2 },
                new OrderRow { Id = 4, Quantity = 6, ProductId = 7, OrderId = 2 },
                new OrderRow { Id = 5, Quantity = 2, ProductId = 11, OrderId = 3 },
                new OrderRow { Id = 6, Quantity = 1, ProductId = 5, OrderId = 3 },
                new OrderRow { Id = 7, Quantity = 7, ProductId = 9, OrderId = 4 },
                new OrderRow { Id = 8, Quantity = 4, ProductId = 15, OrderId = 4 }
                );

        }

    }
    
}
