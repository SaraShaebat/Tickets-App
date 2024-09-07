using DataAccessLayer.Entities;

namespace BusinessLogicLayer
{
    public static class UserTicketMapper
    {
        // Convert UserTicket entity to UserTicketDTO
        //public static UserTicketDTO ToUserTicketDTO(this UserTicket userTicket)
        //{
        //    return new UserTicketDTO
        //    {
        //        TicketId = userTicket.TicketId,
        //        UserId = userTicket.UserId,
        //        Notes = userTicket.Notes
        //    };
        //}

        // Convert UserTicketDTO to UserTicket entity
        public static UserTicket ToUserTicketEntity(this UserTicketDTO userTicketDto)
        {
            return new UserTicket
            {
                TicketId = userTicketDto.TicketId,
                UserId = userTicketDto.UserId,
                Notes = userTicketDto.Notes
            };
        }

        // Convert UserTicket entity to UserTicketResource
        public static UserTicketResource ToUserTicketResource(this UserTicket userTicket)
        {
            return new UserTicketResource
            {
                TicketId = userTicket.TicketId,
                UserId = userTicket.UserId,
                Notes = userTicket.Notes
            };
        }
    }
}
