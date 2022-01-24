using Spinutech.Models;

using System.Collections.Generic;

namespace Spinutech.Services
{
    public interface ICardService
    {
        bool IsValidHand(List<Card> hand);
    }
}
