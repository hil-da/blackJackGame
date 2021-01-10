using System;
using System.Collections.Generic;
using System.Linq;

namespace blackJack
{
    public class Player
    {
        public List<Card> hand = new List<Card>();
        public Card lastDrawnCard;
        public int lowValue;
        public int highValue;
        public int bestValue;

        public bool dealer { get;  set; } 

        public void Draw(Deck deck) // calculating the new values and adding to hand
        {
            List<Card> handCopy = hand;
            lastDrawnCard = deck.Draw();
            hand.Add(lastDrawnCard);

            if (dealer == true)
            { 
                foreach (Card card in handCopy)
                    if (card.value == 1)
                        card.blackJackValue = 11; // changes the blackjackvalue for ace

                lowValue = handCopy.Sum(card => card.blackJackValue);
                bestValue = lowValue;

            }
            else
            {
                lowValue = handCopy.Sum(card => card.blackJackValue);

                foreach (Card card in handCopy)
                    if (card.value == 1)
                        card.blackJackValue = 11;

                highValue = handCopy.Sum(card => card.blackJackValue);
                bestValue = lowValue;

                if((highValue - 21) < (lowValue - 21))
                    bestValue = lowValue;
                else
                    bestValue = highValue;
            }
        }

        public override string ToString() // returns hand cards
        {
            string currentHand = (dealer ? "\nDealer " : "\nPlayer ") + " hand";
            foreach (Card c in hand)
            {
                currentHand += ", ";
                currentHand += c.ToString();
            }

            return currentHand;
        }

        public void Reset() // resets the values and hand
        {
            hand.Clear();
            highValue = 0;
            lowValue = 0;
            bestValue = 0;
        }
    }
}

