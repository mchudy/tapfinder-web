using AutoMapper;
using PubApp.DataAccess.Entities;
using PubApp.Web.Dtos;

namespace PubApp.Web
{
    internal class MappingsConfig : Profile
    {
        public static void ConfigureMappings()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new MappingsConfig()));
        }

        protected override void Configure()
        {
            CreateMap<BeerStyle, BeerStyleDto>();
        }
    }
}