﻿using SampleMVCSite.Models;
using System.Data.Entity;

namespace SampleMVCSite.Contracts.Data
{
    public class DataContext:DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

    }
}
