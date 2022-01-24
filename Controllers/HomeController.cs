using Microsoft.AspNetCore.Mvc;

using Spinutech.Models;
using Spinutech.Services;

using System.Collections.Generic;

namespace Spinutech.Controllers
{
    /// <summary>
    /// ------------
    /// -Exercise 2-
    /// ------------
    /// Write some code that will evaluate a poker hand and determine its
    /// rank.
    /// Example:
    /// Hand: Ah As 10c 7d 6s(Pair of Aces)
    /// Hand: Kh Kc 3s 3h 2d (2 Pair)
    /// Hand: Kh Qh 6h 2h 9h(Flush)
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IRankService _rankService;
        private readonly ICardService _cardService;

        public HomeController(IRankService rankService, ICardService cardService)
        {
            _rankService = rankService;
            _cardService = cardService;
        }

        /// <summary>
        /// Display form to let user generate a poker hand
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var deckOfCards = new Deck();
            var hand = new Hand();

            var model = new IndexViewModel {
                Deck = deckOfCards.GetFullDeck,
                Hand = hand
            };
        
            return View(model);
        }

        /// <summary>
        /// Process poker hand and display hand rank to user
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index([ModelBinder(Name = "Spinutech.Models.Card")] Hand hand)
        {
            if (_cardService.IsValidHand(hand))
            {
                var model = new ResultsViewModel
                {
                    Hand = hand,
                    Rank = _rankService.GetRank(hand)
                };

                return View("Results", model);
            }
            else
            {
                // not valid hand
                ModelState.AddModelError(string.Empty, "Invalid hand. Make sure you selected 5 cards and they are all distinct.");
                var deckOfCards = new Deck();
                var model = new IndexViewModel
                {
                    Deck = deckOfCards.GetFullDeck,
                    Hand = hand
                };
                return View("Index", model);
            }
        }
    }
}
