using AutoMapper;
using ReservationSystemBackend.Core.DTOs;
using ReservationSystemBackend.Core.Entities;

namespace ReservationSystemBackend.Infraestructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();

            CreateMap<Reservation, ReservationDto>();
            CreateMap<ReservationDto, ReservationDto>();

            CreateMap<ServiceType, ServiceTypeDto>();
            CreateMap<ServiceTypeDto, ServiceType>();
        }
    }
}
