using AutoMapper;
using DAL.Doman.Models.Category;
using MenuAPI.ViewModels;

namespace MenuAPI.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GenericVM, Dessert>().ForMember(x => x.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
            //.ForMember(y => y.Update, ops => ops.MapFrom(dd => DateTime.Now));
        }
    }
}
