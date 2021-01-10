using System;
using System.Collections.Generic;

namespace blackJack
{
    public class Deck
    {
        private int _nrOfDecs;
        private List<Card> _cards = new List<Card>();

        public void Decks() // creating deck
        {
            Card.SuitType suit = Card.SuitType.club;
            for (int i = 0; i < _nrOfDecs; i++) // creates 52 cards
                for (int j = 0; j < 4; j++)
                {
                    switch (j) // assigning suit
                    {
                        case 0:
                            suit = Card.SuitType.club;
                            break;
                        case 1:
                            suit = Card.SuitType.diamond;
                            break;
                        case 2:
                            suit = Card.SuitType.heart;
                            break;
                        case 3:
                            suit = Card.SuitType.spade;
                            break;
                    }

                    for (int k = 0; k < 13; k++) // creating 13 cards in each suit
                        _cards.Add(new Card(k, suit));
                }
        }

        public Deck(int nrOfDecs) // generates deck and shuffles it
        {
            _nrOfDecs = nrOfDecs;
            Decks();
            Shuffle();
        }

        public void Shuffle() // shuffle algorithm
        {
            Random r = new Random();

            for (int n = _cards.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                Card temp = _cards[n];
                _cards[n] = _cards[k];
                _cards[k] = temp;
            }
        }

        public void RNS() // resets the deck and shuffles it
        {
            _cards.Clear();
            Decks();
            Shuffle();
        }

        public Card Draw() // draws the first card in the deck
        {
            Card card = _cards[0];
            _cards.Remove(card);
            return (card);
        }
    }
}
