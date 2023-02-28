using AT_Joao.BLL.Models.DTO;
using AT_Joao.BLL.Models.Entities;
using AutoMapper;

namespace AT_Joao.DAL.Profiles
{
    public class CountriesProfile : Profile
    {
        public CountriesProfile()
        {
            CreateMap<Country, CountryDTO>()
                .ReverseMap();            
        }
    }
}
