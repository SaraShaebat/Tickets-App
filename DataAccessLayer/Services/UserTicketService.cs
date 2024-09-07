using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerSchool.Services
{
    public interface IUserTicketService
    {
        Task<UserTicket> GetByIdAsync(int ticketId, int userId);
        Task AddAsync(UserTicket userTicket);
        Task UpdateAsync(UserTicket userTicket);
        Task DeleteAsync(int ticketId, int userId);
    }

    public class UserTicketService : IUserTicketService
    {
        private readonly AppDbContext db_context;

        public UserTicketService(AppDbContext context)
        {
            db_context = context;
        }

        public async Task<UserTicket> GetByIdAsync(int ticketId, int userId)
        {
            return await db_context.UserTickets.FindAsync(ticketId, userId);
        }
        public async Task AddAsync(UserTicket userTicket)
        {
            await db_context.UserTickets.AddAsync(userTicket);
            await db_context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserTicket userTicket)
        {
            db_context.UserTickets.Update(userTicket);
            await db_context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int ticketId, int userId)
        {
            var userTicket = await db_context.UserTickets.FindAsync(ticketId, userId);
            if (userTicket != null)
            {
                db_context.UserTickets.Remove(userTicket);
                await db_context.SaveChangesAsync();
            }
        }
    }
}