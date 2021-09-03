using AutoMapper;
using SuperHero.Domain.Entities;

namespace SuperHero.Domain.AutoMapperConfig
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<dynamic, Hero>();
        }
    }
}
