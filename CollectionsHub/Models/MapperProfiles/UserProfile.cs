using AutoMapper;
using CollectionsHub.Models.Account;

namespace CollectionsHub.Models.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<RegisterViewModel, User>();

            CreateMap<User, UserInfoViewModel>();
        }
    }
}
