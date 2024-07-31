using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimmyLinq
{
    public static class ComicAnalyzer
    {
        public static IEnumerable<IGrouping<PriceRange, Comic>> GroupComicsByPrice(IEnumerable<Comic> catalog, IReadOnlyDictionary<int, decimal> prices)
        {
            IEnumerable<IGrouping<PriceRange, Comic>> grouped =
                from comic in catalog
                orderby prices[comic.Issue]
                group comic by CalculatePriceRange(comic, prices) into groupedByPrice
                select groupedByPrice;
            return grouped;
        }

        public static IEnumerable<string> GetReviews(IEnumerable<Comic> catalog, IEnumerable<Review> reviews)
        {
            IEnumerable<string> getReview =
                from comic in catalog
                orderby comic.Issue
                join review in reviews
                on comic.Issue equals review.Issue
                select $"{review.Critic} ocenił nr {comic.Issue} '{comic.Name}' na {review.Score}.";
            return getReview;
        }

        private static PriceRange CalculatePriceRange(Comic comic, IReadOnlyDictionary<int, decimal> prices)
        {
            if (prices[comic.Issue] < 100)
                return PriceRange.Tanie;
            else
                return PriceRange.Drogie;
        }
    }
}
