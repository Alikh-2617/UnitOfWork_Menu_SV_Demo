using AutoMapper;
using DAL.Doman.Models.Category;
using MenuAPI.ViewModels;

namespace MenuAPI.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GenericVM, Dessert>();
            //CreateMap<GenericVM, Dinner>();
        }
    }
}
