using DataAccessLayer.Entities;
using BusinessLogicLayer.Resources;

namespace BusinessLogicLayer.Mapping
{
    public static class CompanyMapper
    {
        //// Map from Company entity to CompanyDTO
        //public static CompanyDTO ToCompanyDTO(this Company company)
        //{
        //    return new CompanyDTO
        //    {
        //        Id = company.Id,
        //        Name = company.Name,
        //        Phone = company.Phone,
        //        Email = company.Email,
        //        Address = company.Address,
        //        ProfilePicture = company.ProfilePicture,
        //        IsCustomer = company.IsCustomer
        //    };
        //}

        // Map from CompanyDTO to Company entity
        public static Company ToCompanyEntity(this CompanyDTO companyDto)
        {
            return new Company
            {
                Name = companyDto.Name,
                Phone = companyDto.Phone,
                Email = companyDto.Email,
                Address = companyDto.Address,
                ProfilePicture = companyDto.ProfilePicture,
                IsCustomer = companyDto.IsCustomer
            };
        }

        // Map from CompanyDTO to an existing Company entity
        public static void ToCompanyEntity(this CompanyDTO companyDto, Company company)
        {
            company.Name = companyDto.Name;
            company.Phone = companyDto.Phone;
            company.Email = companyDto.Email;
            company.Address = companyDto.Address;
            company.ProfilePicture = companyDto.ProfilePicture;
            company.IsCustomer = companyDto.IsCustomer;
        }

        // Map from Company entity to CompanyResource
        public static CompanyResource ToCompanyResource(this Company company)
        {
            return new CompanyResource
            {
                Id = company.Id,
                Name = company.Name,
                Phone = company.Phone,
                Email = company.Email,
                Address = company.Address,
                ProfilePicture = company.ProfilePicture,
                IsCustomer = company.IsCustomer
            };
        }
    }
}
