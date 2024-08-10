
namespace JimmyLinq
{
    public class Program
    {
        static void Main(string[] args)
        {
            var done = false;
            while (!done)
            {
                Console.WriteLine("\n[G]rupuj według ceny, [R]ecenzje, inny przycisk aby zakończyć:");
                var keyChar = Console.ReadKey(true).KeyChar.ToString().ToUpper();
                done = keyChar switch
                {
                    "G" => GroupComicsByPrice(),
                    "R" => GetReviews(),
                    _ => true,
                };
            }
        }

        private static bool GroupComicsByPrice()
        {
            var groups = ComicAnalyzer.GroupComicsByPrice(Comic.Catalog, Comic.Prices);
            foreach (var group in groups)
            {
                Console.WriteLine($"Komiksy {group.Key}:");
                foreach (var comic in group)
                    Console.WriteLine($"Nr {comic.Issue} {comic.Name}: {Comic.Prices[comic.Issue]:c}");
            }
            return false;
        }

        private static bool GetReviews()
        {
            var reviews = ComicAnalyzer.GetReviews(Comic.Catalog, Comic.Reviews);
            foreach (var review in reviews)
                Console.WriteLine(review);
            return false;

        }
    }
}
