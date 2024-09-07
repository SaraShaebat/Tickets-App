using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<UserTicket> UserTickets { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Comment
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Ticket)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TicketId);

            // Company
            modelBuilder.Entity<Company>()
                    .HasMany(c => c.Tickets)
                    .WithOne(t => t.Company)
                    .HasForeignKey(t => t.CompanyId);

            modelBuilder.Entity<Company>()
                    .HasMany(c => c.Users)
                    .WithOne(u => u.Company)
                    .HasForeignKey(u => u.CompanyId);

            modelBuilder.Entity<Company>()
                    .HasMany(c => c.Services)
                    .WithOne(s => s.Company)
                    .HasForeignKey(s => s.CompanyId);

            // Priority
            modelBuilder.Entity<Priority>()
                    .HasMany(p => p.Tickets)
                    .WithOne(t => t.Priority)
                    .HasForeignKey(t => t.PriorityId);

            // Service
            modelBuilder.Entity<Service>()
                    .HasMany(s => s.Tickets)
                    .WithOne(t => t.Service)
                    .HasForeignKey(t => t.ServiceId);

            // Status to Ticket relationship
            modelBuilder.Entity<Status>()
                .HasMany(s => s.Tickets)
                .WithOne(t => t.Status)
                .HasForeignKey(t => t.StatusId); 

                    // Ticket
                    modelBuilder.Entity<Ticket>()
                    .HasOne(t => t.Company)
                    .WithMany(c => c.Tickets)
                    .HasForeignKey(t => t.CompanyId);

            modelBuilder.Entity<Ticket>()
                    .HasOne(t => t.Priority)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(t => t.PriorityId);

            modelBuilder.Entity<Ticket>()
                    .HasOne(t => t.TicketType)
                    .WithMany(tt => tt.Tickets)
                    .HasForeignKey(t => t.TicketTypeId);

            modelBuilder.Entity<Ticket>()
                    .HasOne(t => t.Service)
                    .WithMany(s => s.Tickets)
                    .HasForeignKey(t => t.ServiceId);

            modelBuilder.Entity<Ticket>()
                    .HasMany(t => t.UserTickets)
                    .WithOne(ut => ut.Ticket)
                    .HasForeignKey(ut => ut.TicketId);

            modelBuilder.Entity<Ticket>()
                    .HasMany(t => t.Comments)
                    .WithOne(c => c.Ticket)
                    .HasForeignKey(c => c.TicketId);

            // TicketType
            modelBuilder.Entity<TicketType>()
                    .HasMany(tt => tt.Tickets)
                    .WithOne(t => t.TicketType)
                    .HasForeignKey(t => t.TicketTypeId);

            // User
            modelBuilder.Entity<User>()
                    .HasMany(u => u.UserTickets)
                    .WithOne(ut => ut.User)
                    .HasForeignKey(ut => ut.UserId);

            // UserTicket
            modelBuilder.Entity<UserTicket>()
                    .HasKey(ut => new
                    {
                        ut.TicketId,
                        ut.UserId
                    });

            modelBuilder.Entity<UserTicket>()
                .HasOne(ut => ut.Ticket)
                .WithMany(t => t.UserTickets)
                .HasForeignKey(ut => ut.TicketId);

            modelBuilder.Entity<UserTicket>()
                        .HasOne(ut => ut.User)
                        .WithMany(u => u.UserTickets)
                        .HasForeignKey(ut => ut.UserId);


        }
    }
}
