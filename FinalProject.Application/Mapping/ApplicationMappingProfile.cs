using AutoMapper;
using FinalProject.Application.DTO;
using FinalProject.Domain;

namespace FinalProject.Application.Mapping
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile() 
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Ticket, TicketDTO>();
            CreateMap<TicketDTO, Ticket>();
            CreateMap<TicketData, TicketDataDTO>();
            CreateMap<TicketDataDTO, TicketData>();
            CreateMap<Reservation, ReservationDTO>();
            CreateMap<ReservationDTO, Reservation>();
            CreateMap<Payment, PaymentDTO>();
            CreateMap<PaymentDTO, Payment>();
            CreateMap<Operator, OperatorDTO>();
            CreateMap<OperatorDTO, Operator>();
        }
    }
}
