using AutoMapper;
using Pizza_API.Data.DTO;
using Pizza_API.Data.Model;

namespace Pizza_API
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<PizzaDTO, Pizza>();

            CreateMap<ToppingDTO, Topping>();
        }
    }
}
