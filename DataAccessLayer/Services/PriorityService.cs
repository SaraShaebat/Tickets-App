using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayerSchool.Services
{
    public interface IPriorityService
    {
        Task<Priority> GetByIdAsync(int id);
        Task AddAsync(Priority priority);
        Task UpdateAsync(Priority priority);
        Task DeleteAsync(int id);
    }

    public class PriorityService : IPriorityService
    {
        private readonly AppDbContext db_context;

        public PriorityService(AppDbContext context)
        {
            db_context = context;
        }

        public async Task<Priority> GetByIdAsync(int id)
        {
            return await db_context.Priorities.FindAsync(id);
        }

        public async Task AddAsync(Priority priority)
        {
            await db_context.Priorities.AddAsync(priority);
            await db_context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Priority priority)
        {
            db_context.Priorities.Update(priority);
            await db_context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var priority = await db_context.Priorities.FindAsync(id);
            if (priority != null)
            {
                db_context.Priorities.Remove(priority);
                await db_context.SaveChangesAsync();
            }
        }
    }
}