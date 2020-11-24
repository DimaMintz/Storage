using System;
using System.Data.Entity;
 
namespace Storage5.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<OrdersContext>
    {
        protected override void Seed(OrdersContext db)
        {
            db.Products.Add(new Product { Name = "chair", Price = 50, Description = "big chair", CreationDate = DateTime.Now, ExpiredDate = DateTime.Now });
            db.Products.Add(new Product { Name = "table", Price = 150, Description = "big table", CreationDate = DateTime.Now, ExpiredDate = DateTime.Now });
            db.Products.Add(new Product { Name = "lamp", Price = 20, Description = "big lamp", CreationDate = DateTime.Now, ExpiredDate = DateTime.Now });
            db.Products.Add(new Product { Name = "computer", Price = 200, Description = "big computer", CreationDate = DateTime.Now, ExpiredDate = DateTime.Now });
            db.Products.Add(new Product { Name = "phone", Price = 200, Description = "big phone", CreationDate = DateTime.Now, ExpiredDate = DateTime.Now });
            db.Products.Add(new Product { Name = "TV", Price = 250, Description = "big TV", CreationDate = DateTime.Now, ExpiredDate = DateTime.Now });
            db.Products.Add(new Product { Name = "DVD", Price = 670, Description = "big DVD", CreationDate = DateTime.Now, ExpiredDate = DateTime.Now });
            db.Products.Add(new Product { Name = "MP4", Price = 280, Description = "big MP4", CreationDate = DateTime.Now, ExpiredDate = DateTime.Now });

            db.Customers.Add(new Customer { Fname = "avi", Lname = "levi", Address = "ashdod", Phone = "082" });
            db.Customers.Add(new Customer { Fname = "dani", Lname = "cohen", Address = "eilat", Phone = "051" });
            db.Customers.Add(new Customer { Fname = "noa", Lname = "hen", Address = "tel aviv", Phone = "033" });

            db.Orders.Add(new Order { CreationDate = DateTime.Now, EstimatedDate = DateTime.Now, StatusId = 1, CustomerId = 1});
            db.Orders.Add(new Order { CreationDate = DateTime.Now, EstimatedDate = DateTime.Now, StatusId = 2, CustomerId = 2 });
            db.Orders.Add(new Order { CreationDate = DateTime.Now, EstimatedDate = DateTime.Now, StatusId = 3, CustomerId = 3});

            db.Statuses.Add(new Status { Name = "created"});
            db.Statuses.Add(new Status { Name = "sent" });
            db.Statuses.Add(new Status { Name = "accepted" });

            db.OrderProducts.Add(new OrderProduct { OrderId = 1, ProductId = 1 });
            db.OrderProducts.Add(new OrderProduct { OrderId = 1, ProductId = 2 });
            db.OrderProducts.Add(new OrderProduct { OrderId = 2, ProductId = 2 });
            db.OrderProducts.Add(new OrderProduct { OrderId = 3, ProductId = 3 });

            base.Seed(db); //insert into db
        }
    }

}

