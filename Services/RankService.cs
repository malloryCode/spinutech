using Spinutech.Models;

using System.Collections.Generic;
using System.Linq;

namespace Spinutech.Services
{
    
    public class RankService : IRankService
    {
        /// <summary>
        /// Ranks a hand of cards
        /// </summary>
        public Rank GetRank(Hand hand)
        {
            if(IsFlush(hand))
            {
                // check for kind of flush
            }   
        }

        /// <summary>
        /// Checks that all cards have sme suit
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        private bool IsFlush(Hand hand)
        {
            return hand.Cards.GroupBy(x => x.Suit).Count() == 1;
        }
    }
}
