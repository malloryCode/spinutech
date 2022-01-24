using Spinutech.Models;

using System.Collections.Generic;
using System.Linq;

namespace Spinutech.Services
{
    public class CardService : ICardService
    {
        /// <summary>
        /// Valid poker hands have exactly 5 card with no
        /// duplicates
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public bool IsValidHand(Hand hand)
        {
            if (hand.Cards.Count(x => x != null) != 5)
            {
                return false;
            }

            HashSet<string> cards = new HashSet<string>();

            foreach (var card in hand.Cards)
            {
                var cardString = card.Suit.ToString() + card.Value.ToString();
                // if already present, Add returns false
                if (cards.Add(cardString))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
