using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IPriorityManager
    {
        Task<PriorityResource> GetByIdAsync(int id);
        Task<PriorityResource> AddAsync(PriorityDTO priorityDto);
        Task<PriorityResource> UpdateAsync(PriorityDTO priorityDto);
        Task DeleteAsync(int id);
    }

    public class PriorityManager : IPriorityManager
    {
        private readonly AppDbContext db_context;

        public PriorityManager(AppDbContext context)
        {
            db_context = context;
        }

        public async Task<PriorityResource> GetByIdAsync(int id)
        {
            var priority = await db_context.Priorities.FindAsync(id);
            if (priority == null)
            {
                return null;
            }

            return priority.ToPriorityResource(); // Use mapper to convert to resource
        }

        public async Task<PriorityResource> AddAsync(PriorityDTO priorityDto)
        {
            var priority = priorityDto.ToPriorityEntity(); // Use mapper to convert DTO to entity

            await db_context.Priorities.AddAsync(priority);
            await db_context.SaveChangesAsync();

            return priority.ToPriorityResource(); // Use mapper to convert to resource
        }

        public async Task<PriorityResource> UpdateAsync(PriorityDTO priorityDto)
        {
            var priority = await db_context.Priorities.FindAsync(priorityDto.Id);
            if (priority == null)
            {
                throw new NotFoundException("Priority not found!");
            }

            priorityDto.UpdatePriorityEntity(priority); // Use mapper to update the existing entity

            db_context.Priorities.Update(priority);
            await db_context.SaveChangesAsync();

            return priority.ToPriorityResource(); // Use mapper to convert to resource
        }

        public async Task DeleteAsync(int id)
        {
            var priority = await db_context.Priorities.FindAsync(id);
            if (priority == null)
            {
                throw new NotFoundException("Priority not found!");
            }

            db_context.Priorities.Remove(priority);
            await db_context.SaveChangesAsync();
        }
    }
}

