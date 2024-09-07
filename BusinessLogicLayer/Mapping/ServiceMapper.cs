using DataAccessLayer.Entities;

namespace BusinessLogicLayer
{
    public static class ServiceMapper
    {
        // Convert Service entity to ServiceDTO
        //public static ServiceDTO ToServiceDTO(this Service service)
        //{
        //    return new ServiceDTO
        //    {
        //        Id = service.Id,
        //        Name = service.Name,
        //        CompanyId = service.CompanyId
        //    };
        //}

        // Convert ServiceDTO to Service entity
        public static Service ToServiceEntity(this ServiceDTO serviceDto)
        {
            return new Service
            {
                Id = serviceDto.Id,  // Include Id if you want to update existing entity
                Name = serviceDto.Name,
                CompanyId = serviceDto.CompanyId
            };
        }

        // Update existing Service entity with values from ServiceDTO
        public static void UpdateServiceEntity(this ServiceDTO serviceDto, Service service)
        {
            service.Name = serviceDto.Name;
            service.CompanyId = serviceDto.CompanyId;
        }

        // Convert Service entity to ServiceResource
        public static ServiceResource ToServiceResource(this Service service)
        {
            return new ServiceResource
            {
                Id = service.Id,
                Name = service.Name,
                CompanyId = service.CompanyId
            };
        }
    }
}
