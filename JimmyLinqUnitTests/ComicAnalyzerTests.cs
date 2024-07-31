namespace JimmyLinqUnitTests
{
    using JimmyLinq;

    [TestClass]
    public class ComicAnalyzerTests
    {
        IEnumerable<Comic> testComics = new[]
            {
                new Comic() {Issue = 1, Name = "Numer 1" },
                new Comic() {Issue = 2, Name = "Numer 2" },
                new Comic() {Issue = 3, Name = "Numer 3" },
            };

        [TestMethod]
        public void ComicAnalyzer_Should_Group_Comics()
        {
            var prices = new Dictionary<int, decimal>()
            {
                { 1, 20M },
                { 2, 10M },
                { 3, 1000M },
            };

            var groups = ComicAnalyzer.GroupComicsByPrice(testComics, prices);

            Assert.AreEqual(2, groups.Count());
            Assert.AreEqual(PriceRange.Tanie, groups.First().Key);
            Assert.AreEqual(2, groups.First().First().Issue);
            Assert.AreEqual("Numer 2", groups.First().First().Name);
        }
    }
}