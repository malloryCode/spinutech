using System;
using System.Collections.Generic;
using System.Linq;

namespace Spinutech.Models
{
    public class Deck
    {
        public List<Card> GetFullDeck
        {
            get
            {
                var cards = new List<Card>(); ;
                var allSuits = Enum.GetValues<Suit>().ToList();
                var allValues = Enum.GetValues<CardValue>().ToList();

                foreach (var suit in allSuits)
                {
                    foreach (var value in allValues)
                    {
                        cards.Add(new Card
                        {
                            Suit = suit,
                            Value = value
                        });
                    }
                }

                return cards;
            }
        }

        public List<Card> GetShuffledDeck
        {
            get
            {
                var cards = GetFullDeck;

                var rnd = new Random();
                var randomized = cards.OrderBy(item => rnd.Next()).ToList();
                return randomized;
            }
        }
    }
}
