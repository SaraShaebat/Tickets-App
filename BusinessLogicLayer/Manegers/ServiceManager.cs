using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using OpenQA.Selenium;
using System;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IServiceManager
    {
        Task<ServiceResource> GetByIdAsync(int id);
        Task<ServiceResource> AddAsync(ServiceDTO serviceDto);
        Task<ServiceResource> UpdateAsync(ServiceDTO serviceDto);
        Task DeleteAsync(int id);
    }
    public class ServiceManager : IServiceManager
    {
        private readonly AppDbContext db_context;

        public ServiceManager(AppDbContext context)
        {
            db_context = context;
        }

        public async Task<ServiceResource> GetByIdAsync(int id)
        {
            var service = await db_context.Services.FindAsync(id);
            if (service == null)
            {
                return null;
            }

            return service.ToServiceResource(); // Use mapper to convert to resource
        }

        public async Task<ServiceResource> AddAsync(ServiceDTO serviceDto)
        {
            var service = serviceDto.ToServiceEntity(); // Use mapper to convert DTO to entity

            await db_context.Services.AddAsync(service);
            await db_context.SaveChangesAsync();

            return service.ToServiceResource(); // Use mapper to convert to resource
        }

        public async Task<ServiceResource> UpdateAsync(ServiceDTO serviceDto)
        {
            var service = await db_context.Services.FindAsync(serviceDto.Id);
            if (service == null)
            {
                throw new NotFoundException("Service not found!");
            }

            serviceDto.UpdateServiceEntity(service); // Use mapper to update the existing entity

            db_context.Services.Update(service);
            await db_context.SaveChangesAsync();

            return service.ToServiceResource(); // Use mapper to convert to resource
        }

        public async Task DeleteAsync(int id)
        {
            var service = await db_context.Services.FindAsync(id);
            if (service == null)
            {
                throw new NotFoundException("Service not found!");
            }

            db_context.Services.Remove(service);
            await db_context.SaveChangesAsync();
        }
    }
}

