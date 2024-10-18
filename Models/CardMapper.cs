using AutoMapper;

namespace CardGame.Models
{
    public class CardMapper : Profile
    {
        public CardMapper()
        {
            CreateMap<CardModel, CardViewModel>()
                .ForMember(x => x.Suit, m => m.MapFrom(a => a.Suit))
                .ForMember(x => x.FaceValue, m => m.MapFrom(a => a.FaceValue))
                .ForMember(x => x.IntegerValue, m => m.MapFrom(a => a.IntegerValue))
                .ReverseMap();
        }
    }
}
