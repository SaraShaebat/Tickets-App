using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IUserTicketManager
    {
        Task<UserTicketResource> GetByIdAsync(int ticketId, int userId);
        Task<UserTicketResource> AddAsync(UserTicketDTO userTicketDto);
        Task<UserTicketResource> UpdateAsync(UserTicketDTO userTicketDto);
        Task DeleteAsync(int ticketId, int userId);
    }
    public class UserTicketManager : IUserTicketManager
    {
        private readonly AppDbContext db_context;

        public UserTicketManager(AppDbContext context)
        {
            db_context = context;
        }

        public async Task<UserTicketResource> GetByIdAsync(int ticketId, int userId)
        {
            var userTicket = await db_context.UserTickets
                .FirstOrDefaultAsync(ut => ut.TicketId == ticketId && ut.UserId == userId);
            if (userTicket == null)
            {
                return null;
            }

            return userTicket.ToUserTicketResource(); // Use mapper to convert to resource
        }

        public async Task<UserTicketResource> AddAsync(UserTicketDTO userTicketDto)
        {
            var userTicket = userTicketDto.ToUserTicketEntity(); // Use mapper to convert DTO to entity

            await db_context.UserTickets.AddAsync(userTicket);
            await db_context.SaveChangesAsync();

            return userTicket.ToUserTicketResource(); // Use mapper to convert to resource
        }

        public async Task<UserTicketResource> UpdateAsync(UserTicketDTO userTicketDto)
        {
            var userTicket = await db_context.UserTickets
                .FirstOrDefaultAsync(ut => ut.TicketId == userTicketDto.TicketId && ut.UserId == userTicketDto.UserId);
            if (userTicket == null)
            {
                return null;
            }

            userTicket.Notes = userTicketDto.Notes;

            db_context.UserTickets.Update(userTicket);
            await db_context.SaveChangesAsync();

            return userTicket.ToUserTicketResource(); // Use mapper to convert to resource
        }

        public async Task DeleteAsync(int ticketId, int userId)
        {
            var userTicket = await db_context.UserTickets
                .FirstOrDefaultAsync(ut => ut.TicketId == ticketId && ut.UserId == userId);
            if (userTicket != null)
            {
                db_context.UserTickets.Remove(userTicket);
                await db_context.SaveChangesAsync();
            }
        }
    }
}

