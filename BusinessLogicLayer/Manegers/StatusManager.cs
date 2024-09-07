using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using OpenQA.Selenium;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IStatusManager
    {
        Task<StatusResource> GetByIdAsync(int id);
        Task<StatusResource> AddAsync(StatusDTO statusDto);
        Task<StatusResource> UpdateAsync(StatusDTO statusDto);
        Task DeleteAsync(int id);
    }

    public class StatusManager : IStatusManager
    {
        private readonly AppDbContext db_context;

        public StatusManager(AppDbContext context)
        {
            db_context = context;
        }

        public async Task<StatusResource> GetByIdAsync(int id)
        {
            var status = await db_context.Statuses.FindAsync(id);
            if (status == null)
            {
                return null;
            }

            return status.ToStatusResource(); // Use mapper to convert to resource
        }

        public async Task<StatusResource> AddAsync(StatusDTO statusDto)
        {
            var status = statusDto.ToStatusEntity(); // Use mapper to convert DTO to entity

            await db_context.Statuses.AddAsync(status);
            await db_context.SaveChangesAsync();

            return status.ToStatusResource(); // Use mapper to convert to resource
        }

        public async Task<StatusResource> UpdateAsync(StatusDTO statusDto)
        {
            var status = await db_context.Statuses.FindAsync(statusDto.Id);
            if (status == null)
            {
                throw new NotFoundException("Status not found!");
            }

            statusDto.UpdateStatusEntity(status); // Use mapper to update the existing entity

            db_context.Statuses.Update(status);
            await db_context.SaveChangesAsync();

            return status.ToStatusResource(); // Use mapper to convert to resource
        }

        public async Task DeleteAsync(int id)
        {
            var status = await db_context.Statuses.FindAsync(id);
            if (status == null)
            {
                throw new NotFoundException("Status not found!");
            }

            db_context.Statuses.Remove(status);
            await db_context.SaveChangesAsync();
        }
    }
}

