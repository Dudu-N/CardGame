using CardGame.Models;

namespace CardGame.Services
{
    public class ScoreService : IScoreService
    {
        public ScoreService() { }

        public int CalculateScore(PlayerModel player)
        {
            return player.Cards.Select(p => p.IntegerValue).Sum();
        }

        public int GetWinner(List<PlayerModel> players)
        {
            PlayerModel winner = new();

            int maxScore = players.Select(p => p.Score).Max();

            if (players.Where(p => p.Score == maxScore).Count() == 1)
            {
                return players.First(p => p.Score == maxScore).Id;

            }

            return ResolveTie(players.Where(p => p.Score == maxScore).ToList());
        }

        private static int ResolveTie(List<PlayerModel> players)
        {
            foreach (var player in players)
            {
                foreach (var card in player.Cards)
                {
                    player.Score += (int)card.Suit;
                }
            }

            int maxScore = players.Select(p => p.Score).Max();

            return players.First(p => p.Score == maxScore).Id;
        }


    }
}
