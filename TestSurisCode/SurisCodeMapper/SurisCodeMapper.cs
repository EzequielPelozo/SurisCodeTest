using AutoMapper;
using TestSurisCode.Models.Dtos;
using TestSurisCode.Models;

namespace TestSurisCode.SurisCodeMapper
{
    public class SurisCodeMapper : Profile
    {
        public SurisCodeMapper()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<Reservation, CreateReservationDto>().ReverseMap();
        }
    }
}
