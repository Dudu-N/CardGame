namespace CardGame.Models
{
    public class PlayerModel
    {
        public int Id { get; set; }
        public List<CardModel> Cards { get; set; } = [];
        public int Score { get; set; } = 0;
        public bool IsWinner { get; set; } = false;
    }
}
