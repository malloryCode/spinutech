using Microsoft.AspNetCore.Mvc;

using Spinutech.Helpers;

namespace Spinutech.Models
{
    public class Card
    {
        public Suit Suit { get; set; }
        public CardValue Value { get; set; }
    }
}
