using DataAccessLayer.Entities;

namespace BusinessLogicLayer
{
    public static class PriorityMapper
    {
        //// Convert Priority entity to PriorityDTO
        //public static PriorityDTO ToPriorityDTO(this Priority priority)
        //{
        //    return new PriorityDTO
        //    {
        //        Id = priority.Id,
        //        PriorityName = priority.PriorityName
        //    };
        //}

        // Convert PriorityDTO to Priority entity
        public static Priority ToPriorityEntity(this PriorityDTO priorityDto)
        {
            return new Priority
            {
                Id = priorityDto.Id,  // Include Id if you want to update existing entity
                PriorityName = priorityDto.PriorityName
            };
        }

        // Update existing Priority entity with values from PriorityDTO
        public static void UpdatePriorityEntity(this PriorityDTO priorityDto, Priority priority)
        {
            priority.PriorityName = priorityDto.PriorityName;
        }

        // Convert Priority entity to PriorityResource
        public static PriorityResource ToPriorityResource(this Priority priority)
        {
            return new PriorityResource
            {
                Id = priority.Id,
                PriorityName = priority.PriorityName
            };
        }
    }
}
