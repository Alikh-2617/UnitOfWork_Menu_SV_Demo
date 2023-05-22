using AutoMapper;
using DAL.Doman.Models.Category;
using MenuAPI.ViewModels;

namespace MenuAPI.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GenericVM, BreakFast>().ForMember(x => x.Id, opt => opt.MapFrom(src => Guid.NewGuid())).ForMember(y => y.Update, ops => ops.MapFrom(dd => DateTime.Now));
            CreateMap<GenericVM, Dessert>().ForMember(x => x.Id, opt => opt.MapFrom(src => Guid.NewGuid())).ForMember(y => y.Update, ops => ops.MapFrom(dd => DateTime.Now));
            CreateMap<GenericVM, Dinner>().ForMember(x => x.Id, opt => opt.MapFrom(src => Guid.NewGuid())).ForMember(y => y.Update, ops => ops.MapFrom(dd => DateTime.Now));
            CreateMap<GenericVM, Lunch>().ForMember(x => x.Id, opt => opt.MapFrom(src => Guid.NewGuid())).ForMember(y => y.Update, ops => ops.MapFrom(dd => DateTime.Now));
            CreateMap<Drink_SodaVM, Soda>().ForMember(x => x.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<Drink_SodaVM, Drink>().ForMember(x => x.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
        }
    }
}
