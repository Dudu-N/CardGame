using CardGame.Models;

namespace CardGame.Services
{
    public class CardDealerService : ICardDealerService
    {
        private readonly Dictionary<string, List<int>> _cards;
        private readonly List<string> _keys;

        private const string Diamonds = "Diamonds";
        private const string Hearts = "Hearts";
        private const string Spades = "Spades";
        private const string Clubs = "Clubs";

        public CardDealerService()
        {
            _cards = new()
            {
                { Diamonds, GenerateDeckForSuit() },
                { Hearts, GenerateDeckForSuit() },
                { Spades, GenerateDeckForSuit() },
                { Clubs, GenerateDeckForSuit() },
            };

            _keys = [.. _cards.Keys];
        }

        private static List<int> GenerateDeckForSuit()
        {
            return Enumerable.Range(1, 13)
                             .Concat(Enumerable.Range(1, 13))
                             .ToList();
        }

        private CardModel GenerateCard()
        {
            Random random = new();

            int randomKeyIndex = random.Next(_keys.Count);
            string randomKey = _keys[randomKeyIndex];

            int randomValueIndex = random.Next(_cards[randomKey].Count);
            int randomValue = _cards[randomKey][randomValueIndex];

            _cards[randomKey].RemoveAt(randomValueIndex);

            if (_cards[randomKey].Count == 0)
            {
                _cards.Remove(randomKey);
                _keys.Remove(randomKey);
            }

            var suit = randomKey switch
            {
                Diamonds => SuitEnum.Diamonds,
                Hearts => SuitEnum.Hearts,
                Spades => SuitEnum.Spades,
                _ => SuitEnum.Clubs,
            };

            string faceValue;
            int intValue;

            switch (randomValue)
            {
                case 1:
                    faceValue = "A";
                    intValue = 11;
                    break;
                case 11:
                    faceValue = "J";
                    intValue = 11;
                    break;
                case 12:
                    faceValue = "Q";
                    intValue = 12;
                    break;
                case 13:
                    faceValue = "K";
                    intValue = 13;
                    break;
                default:
                    faceValue = randomValue.ToString();
                    intValue = randomValue;
                    break;

            }

            return new CardModel()
            {
                Suit = suit,
                FaceValue = faceValue,
                IntegerValue = intValue,
            };

        }

        private List<CardModel> GenerateCardsForPlayer(int numCards)
        {
            var cards = new List<CardModel>();
            for (int i = 0; i < numCards; i++)
            {
                cards.Add(GenerateCard());
            }

            return cards;
        }

        public List<PlayerModel> DealCardsToPlayers()
        {
            var dealtCards = new List<PlayerModel>();

            for (int i = 1; i <= 6; i++)
            {
                var player = new PlayerModel()
                {
                    Id = i,
                    Cards = GenerateCardsForPlayer(6)
                };
                dealtCards.Add(player);
            }

            return dealtCards;
        }
    }
}
