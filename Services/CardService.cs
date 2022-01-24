using Spinutech.Models;

using System.Collections.Generic;

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
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            HashSet<Card> cards = new HashSet<Card>();

            foreach (var card in hand.Cards)
            {
                // if already present, Add returns false
                if (!cards.Add(card))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
