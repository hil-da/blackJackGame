using System;
namespace blackJack
{
    public class Card
    {
        public int value { get; }
        public int blackJackValue { get; set; }
        public SuitType suit { get; }

        public override string ToString() // Suits
        {
            string suitCard = null;
            switch(suit) 
            {
                case SuitType.club:
                    suitCard = "C";
                    break;
                case SuitType.diamond:
                    suitCard = "D";
                    break;
                case SuitType.heart:
                    suitCard = "H";
                    break;
                case SuitType.spade:
                    suitCard = "S";
                    break;
            }

            return String.Format("{0}{1} (BJV {2})", value, suitCard, blackJackValue); //Writes out when a new card is drawn
        }

        public Card(int value, SuitType suit)
        {
            this.value = value;
            this.suit = suit;

            switch(value) // You could also do this with if statements
            {
                case 0: // Ace
                    blackJackValue = 1;
                    break;
                case 11: // Jack
                    blackJackValue = 10;
                    break;
                case 12: // Queen
                    blackJackValue = 10;
                    break;
                case 13: //King
                    blackJackValue = 10;
                    break;
                default:
                    blackJackValue = value;
                    break;
            }
        }

        public enum SuitType 
        {
            club,
            diamond,
            heart,
            spade
        }
    }
}
