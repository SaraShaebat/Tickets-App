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
    public interface IServiceService
    {
        Task<Service> GetByIdAsync(int id);
        Task AddAsync(Service service);
        Task UpdateAsync(Service service);
        Task DeleteAsync(int id);
    }

    public class ServiceService : IServiceService
    {
        private readonly AppDbContext db_context;

        public ServiceService(AppDbContext context)
        {
            db_context = context;
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            return await db_context.Services.FindAsync(id);
        }

        public async Task AddAsync(Service service)
        {
            await db_context.Services.AddAsync(service);
            await db_context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Service service)
        {
            db_context.Services.Update(service);
            await db_context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var service = await db_context.Services.FindAsync(id);
            if (service != null)
            {
                db_context.Services.Remove(service);
                await db_context.SaveChangesAsync();
            }
        }
    }
}