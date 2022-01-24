using System.ComponentModel.DataAnnotations;

namespace Spinutech.Models
{
    public enum Rank
    {
        [Display( Name = "Royal Flush")]RoyalFlush,
        [Display(Name = "Straight Flush")] StraightFlush,
        [Display(Name = "Four Of A Kind")] FourOfAKind,
        [Display(Name = "Full House")] FullHouse,
        [Display(Name = "Flush")] Flush,
        [Display(Name = "Straight")] Straight,
        [Display(Name = "Three Of A Kind")] ThreeOfAKind,
        [Display(Name = "Two Pair")] TwoPair,
        [Display(Name = "Pair")] Pair,
        [Display(Name = "High Card")] HighCard,
    }
}
