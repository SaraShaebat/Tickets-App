using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using OpenQA.Selenium;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface ITicketTypeManager
    {
        Task<TicketTypeResource> GetByIdAsync(int id);
        Task<TicketTypeResource> AddAsync(TicketTypeDTO ticketTypeDto);
        Task<TicketTypeResource> UpdateAsync(TicketTypeDTO ticketTypeDto);
        Task DeleteAsync(int id);
    }

    public class TicketTypeManager : ITicketTypeManager
    {
        private readonly AppDbContext db_context;

        public TicketTypeManager(AppDbContext context)
        {
            db_context = context;
        }

        public async Task<TicketTypeResource> GetByIdAsync(int id)
        {
            var ticketType = await db_context.TicketTypes.FindAsync(id);
            if (ticketType == null)
            {
                return null;
            }

            return ticketType.ToTicketTypeResource(); // Use mapper to convert to resource
        }

        public async Task<TicketTypeResource> AddAsync(TicketTypeDTO ticketTypeDto)
        {
            var ticketType = ticketTypeDto.ToTicketTypeEntity(); // Use mapper to convert DTO to entity

            await db_context.TicketTypes.AddAsync(ticketType);
            await db_context.SaveChangesAsync();

            return ticketType.ToTicketTypeResource(); // Use mapper to convert to resource
        }

        public async Task<TicketTypeResource> UpdateAsync(TicketTypeDTO ticketTypeDto)
        {
            var ticketType = await db_context.TicketTypes.FindAsync(ticketTypeDto.Id);
            if (ticketType == null)
            {
                throw new NotFoundException("TicketType not found!");
            }

            ticketTypeDto.UpdateTicketTypeEntity(ticketType); // Use mapper to update the existing entity

            db_context.TicketTypes.Update(ticketType);
            await db_context.SaveChangesAsync();

            return ticketType.ToTicketTypeResource(); // Use mapper to convert to resource
        }

        public async Task DeleteAsync(int id)
        {
            var ticketType = await db_context.TicketTypes.FindAsync(id);
            if (ticketType == null)
            {
                throw new NotFoundException("TicketType not found!");
            }

            db_context.TicketTypes.Remove(ticketType);
            await db_context.SaveChangesAsync();
        }
    }
}
