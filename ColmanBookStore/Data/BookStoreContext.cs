using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColmanBookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ColmanBookStore.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {
        }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Costumer> Costumers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .HasOne(p => p.Order)
                .WithMany(b => b.OrderItems)
                .HasForeignKey(p => p.OrderID);

        }

        public void InitializeProducts()
        {
            var dizengoff = new Branch
            {
                branchName = "Dizengoff Center Mall",
                addressInfo = "Dizengoff Street 53 Tel Aviv-Yafo",
                latitude = (float)32.075222,
                longitude = (float)34.775200
            };

            var azrieli = new Branch
            {
                branchName = "Azrieli Mall",
                addressInfo = "Menachem Begin Road 132 Tel Aviv-Yafo",
                latitude = (float)32.074775,
                longitude = (float)34.791142
            };

            var tlv = new Branch
            {
                branchName = "Gindi TLV Mall",
                addressInfo = "Hahashmonaim Street 92 Tel Aviv-Yafo",
                latitude = (float)32.069338,
                longitude = (float)34.784807
            };
            Branches.AddRange(dizengoff, azrieli, tlv);

            var admin1 = new Admin
            {
                Email = "admin1@gmail.com",
                FullName = "admin1",
                Password = "1234"
            };

            var admin2 = new Admin
            {
                Email = "admin2@gmail.com",
                FullName = "admin2",
                Password = "1234"
            };

            var admin3 = new Admin
            {
                Email = "admin3@gmail.com",
                FullName = "admin3",
                Password = "1234"
            };

            Admins.AddRange(admin1, admin2, admin3);

            var adventure = new Category
            {
                Name = "Adventure"
            };

            var fantasy = new Category
            {
                Name = "Fantasy"
            };

            var romance = new Category
            {
                Name = "Romance"
            };

            var mystery = new Category
            {
                Name = "Mystery"
            };

            var sciFi = new Category
            {
                Name = "Science Fiction"
            };

            var biography = new Category
            {
                Name = "Biography"
            };

            Categories.AddRange(adventure, fantasy, romance, mystery, sciFi, biography);

            var countMonteCristo = new Product
            {
                Name = "The Count of Monte Cristo",
                Category = adventure,
                IsDeleted = false,
                Price = 65,
                ImgPath = "https://d28hgpri8am2if.cloudfront.net/book_images/onix/cvr9781620875834/the-count-of-monte-cristo-9781620875834_hr.jpg"
            };

            var theHobbit = new Product
            {
                Name = "The Hobbit",
                Category = fantasy,
                IsDeleted = false,
                Price = 60,
                ImgPath = "https://upload.wikimedia.org/wikipedia/en/thumb/3/30/Hobbit_cover.JPG/170px-Hobbit_cover.JPG"
            };

            var gameOfThrones = new Product
            {
                Name = "A Game of Thrones",
                Category = fantasy,
                IsDeleted = false,
                Price = 60,
                ImgPath = "https://images-na.ssl-images-amazon.com/images/I/81q1AybR-ZL.jpg"
            };

            var janeEyre = new Product
            {
                Name = "Jane Eyre",
                Category = romance,
                IsDeleted = false,
                Price = 75,
                ImgPath = "https://images-na.ssl-images-amazon.com/images/I/91zU70Aw9IS.jpg"
            };

            var pridePrejudice = new Product
            {
                Name = "Pride and Prejudice",
                Category = romance,
                IsDeleted = false,
                Price = 50,
                ImgPath = "https://i.harperapps.com/hcanz/covers/9780008195496/y648.jpg"
            };

            var daVinciCode = new Product
            {
                Name = "The Da Vinci Code",
                Category = mystery,
                IsDeleted = false,
                Price = 60,
                ImgPath = "https://muse.10buy.co.il/images/products/og/4813/0b642cfbbf1fb2d3b8a183f0e6df7642_51hYdKyWYqL.jpg"
            };

            var solaris = new Product
            {
                Name = "Solaris",
                Category = sciFi,
                IsDeleted = false,
                Price = 60,
                ImgPath = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1498631519l/95558.jpg"
            };

            var dune = new Product
            {
                Name = "Dune",
                Category = sciFi,
                IsDeleted = false,
                Price = 70,
                ImgPath = "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1555447414l/44767458.jpg"
            };

            var churchillLife = new Product
            {
                Name = "Churchill: A Life",
                Category = biography,
                IsDeleted = false,
                Price = 85,
                ImgPath = "https://images-na.ssl-images-amazon.com/images/I/71fHmlf0r9L.jpg"
            };

            Products.AddRange(
                countMonteCristo,
                theHobbit,
                gameOfThrones,
                janeEyre,
                pridePrejudice,
                daVinciCode,
                solaris,
                dune,
                churchillLife
            );

            var statusNew = new OrderStatus
            {
                Name = "New"
            };

            var statusSent = new OrderStatus
            {
                Name = "Delivered"
            };

            var statusAccepted = new OrderStatus
            {
                Name = "Accepted"
            };

            OrderStatuses.AddRange(statusNew, statusAccepted, statusSent);

            var aviya = new Costumer
            {
                Email = "aviya@gmail.com",
                FirstName = "Aviya",
                LastName = "Shirian"
            };

            var ofir = new Costumer
            {
                Email = "ofir@gmail.com",
                FirstName = "Ofir",
                LastName = "Inbar"
            };

            var shay = new Costumer
            {
                Email = "shay@gmail.com",
                FirstName = "Shay",
                LastName = "Cohen"
            };

            Costumers.AddRange(aviya, ofir, shay);

            Order order1 = new Order
            {
                Address = "bla 5 tel aviv",
                CCCvv = "999",
                CCExpiration = "02/25",
                CCName = "Ofir Inbar",
                CCNumber = "1234123412341234",
                Costumer = ofir,
                OrderDate = new DateTime(2021, 6, 4),
                Status = statusSent,
                Zip = "12345678",
                OrderItems = new List<OrderItem>()
            };

            OrderItem item11 = new OrderItem
            {
                Order = order1,
                OrderID = order1.Id,
                Product = churchillLife,
                Quantity = 1
            };

            OrderItem item12 = new OrderItem
            {
                Order = order1,
                OrderID = order1.Id,
                Product = theHobbit,
                Quantity = 3
            };

            order1.OrderItems.Add(item11);
            order1.OrderItems.Add(item12);

            Order order2 = new Order
            {
                Address = "rotchild 25 tel aviv",
                CCCvv = "567",
                CCExpiration = "09/23",
                CCName = "Shay Cohen",
                CCNumber = "4545454545454545",
                Costumer = shay,
                OrderDate = new DateTime(2021, 5, 28),
                Status = statusSent,
                Zip = "67896789",
                OrderItems = new List<OrderItem>()
            };

            OrderItem item21 = new OrderItem
            {
                Order = order2,
                OrderID = order2.Id,
                Product = pridePrejudice,
                Quantity = 1
            };

            OrderItem item22 = new OrderItem
            {
                Order = order2,
                OrderID = order2.Id,
                Product = theHobbit,
                Quantity = 2
            };

            OrderItem item23 = new OrderItem
            {
                Order = order2,
                OrderID = order2.Id,
                Product = janeEyre,
                Quantity = 1
            };

            order2.OrderItems.Add(item21);
            order2.OrderItems.Add(item22);
            order2.OrderItems.Add(item23);

            Order order3 = new Order
            {
                Address = "rotchild 25 tel aviv",
                CCCvv = "567",
                CCExpiration = "09/23",
                CCName = "Shay Cohen",
                CCNumber = "4545454545454545",
                Costumer = shay,
                OrderDate = new DateTime(2021, 5, 28),
                Status = statusAccepted,
                Zip = "67896789",
                OrderItems = new List<OrderItem>()
            };

            OrderItem item31 = new OrderItem
            {
                Order = order3,
                OrderID = order3.Id,
                Product = countMonteCristo,
                Quantity = 1
            };

            OrderItem item32 = new OrderItem
            {
                Order = order3,
                OrderID = order3.Id,
                Product = solaris,
                Quantity = 1
            };

            OrderItem item33 = new OrderItem
            {
                Order = order3,
                OrderID = order3.Id,
                Product = daVinciCode,
                Quantity = 2
            };

            order3.OrderItems.Add(item31);
            order3.OrderItems.Add(item32);
            order3.OrderItems.Add(item33);

            Orders.AddRange(order1, order2, order3);

            SaveChanges();
        }
    }
}
