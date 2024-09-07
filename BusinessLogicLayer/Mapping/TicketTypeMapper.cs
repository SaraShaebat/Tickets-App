using DataAccessLayer.Entities;

namespace BusinessLogicLayer
{
    public static class TicketTypeMapper
    {
        // Convert TicketType entity to TicketTypeDTO
        //public static TicketTypeDTO ToTicketTypeDTO(this TicketType ticketType)
        //{
        //    return new TicketTypeDTO
        //    {
        //        Id = ticketType.Id,
        //        TypeName = ticketType.TypeName
        //    };
        //}

        // Convert TicketTypeDTO to TicketType entity
        public static TicketType ToTicketTypeEntity(this TicketTypeDTO ticketTypeDto)
        {
            return new TicketType
            {
                Id = ticketTypeDto.Id, // Include Id if updating an existing entity
                TypeName = ticketTypeDto.TypeName
            };
        }

        // Update existing TicketType entity with values from TicketTypeDTO
        public static void UpdateTicketTypeEntity(this TicketTypeDTO ticketTypeDto, TicketType ticketType)
        {
            ticketType.TypeName = ticketTypeDto.TypeName;
        }

        // Convert TicketType entity to TicketTypeResource
        public static TicketTypeResource ToTicketTypeResource(this TicketType ticketType)
        {
            return new TicketTypeResource
            {
                Id = ticketType.Id,
                TypeName = ticketType.TypeName
            };
        }
    }
}
