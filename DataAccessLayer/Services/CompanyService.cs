using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerSchool.Services
{
    public interface ICompanyService
    {
        Task<Company> GetByIdAsync(int id);
        Task AddAsync(Company company);
        Task UpdateAsync(Company company);
        Task DeleteAsync(int id);
    }

    public class CompanyService : ICompanyService
    {
        private readonly AppDbContext db_context;

        public CompanyService(AppDbContext context)
        {
            db_context = context;
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await db_context.Companies.FindAsync(id);
        }

        public async Task AddAsync(Company company)
        {
            await db_context.Companies.AddAsync(company);
            await db_context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company company)
        {
            db_context.Companies.Update(company);
            await db_context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var company = await db_context.Companies.FindAsync(id);
            if (company != null)
            {
                db_context.Companies.Remove(company);
                await db_context.SaveChangesAsync();
            }
        }
    }
}