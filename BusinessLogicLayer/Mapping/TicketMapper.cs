using DataAccessLayer.Entities;

namespace BusinessLogicLayer
{
    public static class TicketMapper
    {
        // Convert Ticket entity to TicketDTO
        //public static TicketDTO ToTicketDTO(this Ticket ticket)
        //{
        //    return new TicketDTO
        //    {
        //        Id = ticket.Id,
        //        Title = ticket.Title,
        //        Description = ticket.Description,
        //        StatusId = ticket.StatusId,
        //        PriorityId = ticket.PriorityId,
        //        CompanyId = ticket.CompanyId,
        //        TicketTypeId = ticket.TicketTypeId,
        //        ServiceId = ticket.ServiceId,
        //        DeadLine = ticket.DeadLine
        //    };
        //}

        // Convert TicketDTO to Ticket entity
        public static Ticket ToTicketEntity(this TicketDTO ticketDto)
        {
            return new Ticket
            {
                Id = ticketDto.Id, // Include Id if you want to update an existing entity
                Title = ticketDto.Title,
                Description = ticketDto.Description,
                StatusId = ticketDto.StatusId,
                PriorityId = ticketDto.PriorityId,
                CompanyId = ticketDto.CompanyId,
                TicketTypeId = ticketDto.TicketTypeId,
                ServiceId = ticketDto.ServiceId,
                DeadLine = ticketDto.DeadLine
            };
        }

        // Update existing Ticket entity with values from TicketDTO
        public static void UpdateTicketEntity(this TicketDTO ticketDto, Ticket ticket)
        {
            ticket.Title = ticketDto.Title;
            ticket.Description = ticketDto.Description;
            ticket.StatusId = ticketDto.StatusId;
            ticket.PriorityId = ticketDto.PriorityId;
            ticket.CompanyId = ticketDto.CompanyId;
            ticket.TicketTypeId = ticketDto.TicketTypeId;
            ticket.ServiceId = ticketDto.ServiceId;
            ticket.DeadLine = ticketDto.DeadLine;
        }

        // Convert Ticket entity to TicketResource
        public static TicketResource ToTicketResource(this Ticket ticket)
        {
            return new TicketResource
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                StatusId = ticket.StatusId,
                StatusName = ticket.Status.StatusName,
                PriorityId = ticket.PriorityId,
                PriorityName = ticket.Priority.PriorityName,
                CompanyId = ticket.CompanyId,
                CompanyName = ticket.Company.Name,
                TicketTypeId = ticket.TicketTypeId,
                ServiceId = ticket.ServiceId,
                ServiceName = ticket.Service.Name,
                DeadLine = ticket.DeadLine
            };
        }
    }
}
