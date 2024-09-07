using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerSchool.Services
{
    public interface ITicketService
    {
        Task<Ticket> GetByIdAsync(int id);
        Task AddAsync(Ticket ticket);
        Task UpdateAsync(Ticket ticket);
        Task DeleteAsync(int id);
    }

    public class TicketService : ITicketService
    {
        private readonly AppDbContext db_context;

        public TicketService(AppDbContext context)
        {
            db_context = context;
        }
        //public async Task<Ticket> GetByIdAsync(int id)
        //{
        //    return await db_context.TicketTypes.FindAsync(id);
        //}

        public async Task<Ticket> GetByIdAsync(int id)
        {
            var ticket = await db_context.Tickets.FindAsync(id);

            if (ticket != null)
            {
                ticket.UserTickets = await db_context.UserTickets.Where(ut => ut.TicketId == id).ToListAsync();
            }

            return ticket;
        }



        public async Task AddAsync(Ticket ticket)
        {
            await db_context.Tickets.AddAsync(ticket);
            await db_context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            db_context.Tickets.Update(ticket);
            await db_context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ticket = await db_context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                db_context.Tickets.Remove(ticket);
                await db_context.SaveChangesAsync();
            }
        }
    }
}
