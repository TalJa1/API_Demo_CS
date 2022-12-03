﻿using Demo_API_NET5.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo_API_NET5.Datas
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Wallet> Wallet { get; set; }
    }
}
