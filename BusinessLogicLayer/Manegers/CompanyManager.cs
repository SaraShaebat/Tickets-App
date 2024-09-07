using BusinessLogicLayer.Mapping;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface ICompanyManager
    {
        Task<CompanyResource> GetByIdAsync(int id);
        Task<CompanyResource> AddAsync(CompanyDTO companyDto);
        Task<CompanyResource> UpdateAsync(CompanyDTO companyDto);
        Task DeleteAsync(int id);
    }
    public class CompanyManager : ICompanyManager
    {
        private readonly AppDbContext db_context;

        public CompanyManager(AppDbContext context)
        {
            db_context = context;
        }

        public async Task<CompanyResource> GetByIdAsync(int id)
        {
            var company = await db_context.Companies.FindAsync(id);
            if (company == null)
            {
                return null;
            }

            return company.ToCompanyResource();
        }

        public async Task<CompanyResource> AddAsync(CompanyDTO companyDto)
        {
            var company = companyDto.ToCompanyEntity();

            await db_context.Companies.AddAsync(company);
            await db_context.SaveChangesAsync();

            return company.ToCompanyResource();
        }

        public async Task<CompanyResource> UpdateAsync(CompanyDTO companyDto)
        {
            var company = await db_context.Companies.FindAsync(companyDto.Id);
            if (company == null)
            {
                throw new NotFoundException("Company not found!");
            }

            companyDto.ToCompanyEntity(company);

            db_context.Companies.Update(company);
            await db_context.SaveChangesAsync();

            return company.ToCompanyResource();
        }

        public async Task DeleteAsync(int id)
        {
            var company = await db_context.Companies.FindAsync(id);
            if (company == null)
            {
                throw new NotFoundException("Company not found!");
            }

            db_context.Companies.Remove(company);
            await db_context.SaveChangesAsync();
        }
    }
}

