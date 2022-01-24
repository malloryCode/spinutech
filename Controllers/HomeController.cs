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

        public HomeController(IRankService rankService)
        {
            _rankService = rankService;
        }

        /// <summary>
        /// Display form to let user generate a poker hand
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index(List<Card> hand)
        {
            if (hand.Count == 5)
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
                return View(hand);
            }
        }
    }
}
