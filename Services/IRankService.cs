using Spinutech.Models;

using System.Collections.Generic;

namespace Spinutech.Services
{
    public interface IRankService
    {
        Rank GetRank(List<Card> hand);
    }
}
