using DataAccessLayer.Entities;

namespace BusinessLogicLayer
{
    public static class StatusMapper
    {
        // Convert Status entity to StatusDTO
        //public static StatusDTO ToStatusDTO(this Status status)
        //{
        //    return new StatusDTO
        //    {
        //        Id = status.Id,
        //        StatusName = status.StatusName
        //    };
        //}

        // Convert StatusDTO to Status entity
        public static Status ToStatusEntity(this StatusDTO statusDto)
        {
            return new Status
            {
                Id = statusDto.Id, // Include Id if you want to update existing entity
                StatusName = statusDto.StatusName
            };
        }

        // Update existing Status entity with values from StatusDTO
        public static void UpdateStatusEntity(this StatusDTO statusDto, Status status)
        {
            status.StatusName = statusDto.StatusName;
        }

        // Convert Status entity to StatusResource
        public static StatusResource ToStatusResource(this Status status)
        {
            return new StatusResource
            {
                Id = status.Id,
                StatusName = status.StatusName
            };
        }
    }
}
