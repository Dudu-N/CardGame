using AutoMapper;

namespace CardGame.Models
{
    public class PlayerMapper : Profile
    {
        public PlayerMapper()
        {
            CreateMap<PlayerModel, PlayerViewModel>()
                .ForMember(x => x.Id, m => m.MapFrom(a => a.Id))
                .ForMember(x => x.Score, m => m.MapFrom(a => a.Score))
                .ForMember(x => x.Cards, m => m.MapFrom(a => a.Cards))
                .ForMember(x => x.IsWinner, m => m.MapFrom(m => m.IsWinner))
                .ReverseMap();
        }
    }
}
