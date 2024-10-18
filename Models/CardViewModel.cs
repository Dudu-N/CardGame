namespace CardGame.Models
{
    public class CardViewModel
    {
        public SuitEnum Suit { get; set; }
        public string FaceValue { get; set; } = string.Empty;
        public int IntegerValue { get; set; }
    }
}
