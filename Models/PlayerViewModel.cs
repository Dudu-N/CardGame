namespace CardGame.Models
{
    public class PlayerViewModel
    {
        public int Id { get; set; }
        public List<CardViewModel> Cards { get; set; } = [];
        public int Score { get; set; } = 0;
        public bool IsWinner { get; set; } = false;
    }
}
