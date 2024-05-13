using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using System;
using Models;

namespace Data{
    public class Context : DbContext{
        public string connection = "Server=localhost; User Id=root;Database=warehousemaganement";
        public DbSet<Warehouse> warehouses {get; set;}
        public DbSet<Balance> balances {get; set;}
        public DbSet<Product> products {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql(connection, ServerVersion.AutoDetect(connection));
    }
}