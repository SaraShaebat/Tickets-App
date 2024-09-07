using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface ITicketManager
    {
        Task<TicketResource> GetByIdAsync(int id);
        Task<TicketResource> AddAsync(TicketDTO ticketDto);
        Task<TicketResource> UpdateAsync(TicketDTO ticketDto);
        Task DeleteAsync(int id);
    }
    public class TicketManager : ITicketManager
    {
        private readonly AppDbContext db_context;

        public TicketManager(AppDbContext context)
        {
            db_context = context;
        }

        public async Task<TicketResource> GetByIdAsync(int id)
        {
            var ticket = await db_context.Tickets
                .Include(t => t.Status)
                .Include(t => t.Priority)
                .Include(t => t.Company)
                .Include(t => t.Service)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (ticket == null)
            {
                return null;
            }

            return ticket.ToTicketResource(); // Use mapper to convert to resource
        }

        public async Task<TicketResource> AddAsync(TicketDTO ticketDto)
        {
            var ticket = ticketDto.ToTicketEntity(); // Use mapper to convert DTO to entity

            await db_context.Tickets.AddAsync(ticket);
            await db_context.SaveChangesAsync();

            return ticket.ToTicketResource(); // Use mapper to convert to resource
        }

        public async Task<TicketResource> UpdateAsync(TicketDTO ticketDto)
        {
            var ticket = await db_context.Tickets.FindAsync(ticketDto.Id);
            if (ticket == null)
            {
                throw new NotFoundException("Ticket not found!");
            }

            ticketDto.UpdateTicketEntity(ticket); // Use mapper to update the existing entity

            db_context.Tickets.Update(ticket);
            await db_context.SaveChangesAsync();

            return ticket.ToTicketResource(); // Use mapper to convert to resource
        }

        public async Task DeleteAsync(int id)
        {
            var ticket = await db_context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                throw new NotFoundException("Ticket not found!");
            }

            db_context.Tickets.Remove(ticket);
            await db_context.SaveChangesAsync();
        }
    }
}
