using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayerSchool.Services
{
    public interface IStatusService
    {
        Task<Status> GetByIdAsync(int id);
        Task AddAsync(Status status);
        Task UpdateAsync(Status status);
        Task DeleteAsync(int id);
    }

    public class StatusService : IStatusService
    {
        private readonly AppDbContext db_context;

        public StatusService(AppDbContext context)
        {
            db_context = context;
        }

        public async Task<Status> GetByIdAsync(int id)
        {
            return await db_context.Statuses.FindAsync(id);
        }

        public async Task AddAsync(Status status)
        {
            await db_context.Statuses.AddAsync(status);
            await db_context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Status status)
        {
            db_context.Statuses.Update(status);
            await db_context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var status = await db_context.Statuses.FindAsync(id);
            if (status != null)
            {
                db_context.Statuses.Remove(status);
                await db_context.SaveChangesAsync();
            }
        }
    }
}