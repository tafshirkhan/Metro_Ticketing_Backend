using MetroTicketing.System.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro.Ticketing.DAL.DatabaseContext
{
    public class MetroTicketingDbContext : DbContext
    {
        public MetroTicketingDbContext(DbContextOptions<MetroTicketingDbContext> options) : base(options)
        {

        }

        public DbSet<Train> trains { get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Seat> seat { get; set; }
        public DbSet<BankCredential> bankCred { get; set; }
        public DbSet<Transaction> transaction { get; set; }
        public DbSet<Passenger> passenger { get; set; }
    }
}
