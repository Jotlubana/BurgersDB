using System;
using System.Collections.Generic;
using System.Text;
using BurgersDB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BurgersDB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Order> TOrders { get; set; }
        public DbSet<Burger> burgers { get; set; }
        public DbSet<Client> TClients { get; set; }
    }
}
