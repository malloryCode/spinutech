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
            var sortedHand = hand.Cards.OrderBy( x => (int) x.Value).ToList();

            if(IsFlush(hand))
            {
                // check for kind of flush
                if (IsSequence(sortedHand))
                {
                    if (sortedHand.First().Value == CardValue.Ace)
                    {
                        return Rank.RoyalFlush;
                    }
                    else
                    {
                        return Rank.StraightFlush;
                    }
                }
                return Rank.Flush;
            }

            if (IsSequence(sortedHand))
            {
                // must be a straight
                return Rank.Straight;
            }

            var matchingCards = MatchCountMax(sortedHand);

            switch (matchingCards)
            {
                case 4:
                    return Rank.FourOfAKind;
                case 3:
                    // check for full house
                    if (MatchCountMin(sortedHand) == 2)
                    {
                        return Rank.FullHouse;
                    }
                    return Rank.ThreeOfAKind;

                case 2:
                    // check for two pair
                    if (MatchCountMin(sortedHand) == 2)
                    {
                        return Rank.TwoPair;
                    }
                    return Rank.Pair;
                default:
                    return Rank.HighCard;
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

        /// <summary>
        /// Returns true if cards are sequential. Cards are sorted
        /// </summary>
        /// <param name="hand">SORTED, low to high cards</param>
        /// <returns></returns>
        private bool IsSequence(List<Card> cards)
        {
            for(int i = 1; i< cards.Count; i++)
            {
                // current card equal to one more than previous
                if ((int)cards[i].Value != ((int)cards[i-1].Value + 1))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Returns the maximum number of cards of the same value
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private int MatchCountMax(List<Card> cards)
        {
            var matches = cards.GroupBy(x => x.Value);
            return matches.First().Count();
        }

        private int MatchCountMin(List<Card> cards)
        {
            var matches = cards.GroupBy(x => x.Value);
            return matches.ElementAt(2).Count();
        }
    }
}
