
using AutoMapper;

namespace DAL
{
    public static class MappingConfigurator
    {
        public static MapperConfiguration Config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Models.BetSite, DTO.BetSite>();
            cfg.CreateMap<DTO.BetSite, Models.BetSite>();

            cfg.CreateMap<Models.BetSiteLink, DTO.BetSiteLink>();
            cfg.CreateMap<DTO.BetSiteLink, Models.BetSiteLink>();

            cfg.CreateMap<Models.Country, DTO.Country>();
            cfg.CreateMap<DTO.Country, Models.Country>();

            cfg.CreateMap<Models.Category, DTO.Category>();
            cfg.CreateMap<DTO.Category, Models.Category>();

            cfg.CreateMap<Models.League, DTO.League>();
            cfg.CreateMap<DTO.League, Models.League>();

            cfg.CreateMap<Models.Team, DTO.Team>();
            cfg.CreateMap<DTO.Team, Models.Team>();

            cfg.CreateMap<Models.PlayerBet, DTO.PlayerBet>();
            cfg.CreateMap<DTO.PlayerBet, Models.PlayerBet>();

            cfg.CreateMap<Models.Event, DTO.Event>();
            cfg.CreateMap<DTO.Event, Models.Event>();

            cfg.CreateMap<Models.BetSiteEvent, DTO.BetSiteEvent>();
            cfg.CreateMap<DTO.BetSiteEvent, Models.BetSiteEvent>();

            cfg.CreateMap<Models.BotStatics, DTO.BotStatics>();
            cfg.CreateMap<DTO.BotStatics, Models.BotStatics>();
        });

        public static IMapper Mapper = Config.CreateMapper();
    }
}
