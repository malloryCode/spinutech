
using Microsoft.AspNetCore.Mvc;

using Spinutech.Binders;

using System.Collections.Generic;

namespace Spinutech.Models
{
    [ModelBinder(BinderType = typeof(HandTypeBinder))]
    public class Hand
    {
        List<Card> _cards;

        /// <summary>
        /// By default adds 5 empty cards
        /// </summary>
        public Hand()
        {
            _cards = new List<Card>();
            for (int i = 0; i < 5; i++)
            {
                _cards.Add(new Card());
            }
        }

        public List<Card> Cards { get { return _cards; } set { _cards = value; } }
    }
}
