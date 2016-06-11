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
            CreateMap<Brewery, BreweryDto>();
            CreateMap<Beer, BeerDto>()
                .ForMember(b => b.Style, opt => opt.MapFrom(b => b.Style.Name))
                .ForMember(b => b.StyleId, opt => opt.MapFrom(b => b.BeerStyleId));
            CreateMap<Beer, BeerDetailsDto>()
                .ForMember(b => b.Style, opt => opt.MapFrom(b => b.Style.Name))
                .ForMember(b => b.StyleId, opt => opt.MapFrom(b => b.BeerStyleId));
            CreateMap<PlaceBeer, PlaceBeerDto>()
                .ForMember(p => p.UserName, opt => opt.MapFrom(pb => pb.User.UserName))
                .ForMember(b => b.Rating, opt => opt.Ignore());
            CreateMap<PlaceBeerDto, PlaceBeer>();
            CreateMap<PlaceBeer, PlaceWithBeerDto>();
            CreateMap<AddPlaceBeerDto, PlaceBeer>();
            CreateMap<AddSpecialOfferDto, SpecialOffer>();
            CreateMap<SpecialOffer, SpecialOfferDto>()
                .ForMember(s => s.UserName, opt => opt.MapFrom(s => s.User.UserName));
            CreateMap<Comment, CommentDto>()
                .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.User.UserName));
            CreateMap<CommentDto, Comment>();
            CreateMap<User, UserDto>();
            CreateMap<LikeDto, Like>();
        }
    }
}