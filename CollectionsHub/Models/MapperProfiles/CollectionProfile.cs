using AutoMapper;
using CollectionsHub.Models.Account;

namespace CollectionsHub.Models.MapperProfiles
{
    public class CollectionProfile : Profile
    {
        public CollectionProfile()
        {
            CreateMap<Collection, CollectionDetailsViewModel>().ForMember(dest => dest.Collection, opt => opt.MapFrom(src => src)).ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }

    }
}
