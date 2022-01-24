using System.Collections.Generic;

namespace Spinutech.Models
{
    public class IndexViewModel
    { 
        /// <summary>
        /// Deck used for setting up hand
        /// </summary>
        public List<Card> Deck {get; set;}

        /// <summary>
        /// Hand user puts togethrer to be evaluated
        /// </summary>
        public Hand Hand {get; set;}
    }
}
