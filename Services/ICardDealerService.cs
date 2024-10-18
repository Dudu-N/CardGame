using CardGame.Models;

namespace CardGame.Services
{
    public interface ICardDealerService
    {
        List<PlayerModel> DealCardsToPlayers();
    }
}
