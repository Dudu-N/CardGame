using CardGame.Models;

namespace CardGame.Services
{
    public interface IScoreService
    {
        int CalculateScore(PlayerModel player);
        int GetWinner(List<PlayerModel> players);
    }
}
