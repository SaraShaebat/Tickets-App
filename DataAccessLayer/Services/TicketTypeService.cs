using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayerSchool.Services
{
    public interface ITicketTypeService
    {
        Task<TicketType> GetByIdAsync(int id);
        Task AddAsync(TicketType ticketType);
        Task UpdateAsync(TicketType ticketType);
        Task DeleteAsync(int id);
    }

    public class TicketTypeService : ITicketTypeService
    {
        private readonly AppDbContext db_context;

        public TicketTypeService(AppDbContext context)
        {
            db_context = context;
        }

        public async Task<TicketType> GetByIdAsync(int id)
        {
            return await db_context.TicketTypes.FindAsync(id);
        }

        public async Task AddAsync(TicketType ticketType)
        {
            await db_context.TicketTypes.AddAsync(ticketType);
            await db_context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TicketType ticketType)
        {
            db_context.TicketTypes.Update(ticketType);
            await db_context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ticketType = await db_context.TicketTypes.FindAsync(id);
            if (ticketType != null)
            {
                db_context.TicketTypes.Remove(ticketType);
                await db_context.SaveChangesAsync();
            }
        }
    }
}