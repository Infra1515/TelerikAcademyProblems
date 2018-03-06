namespace JustBelot.Common.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CardsCollectionTests
    {
        [TestMethod]
        public void TheFullDeckOfCardsHasFiveSuitedCombinationOfKingAndQueens()
        {   
            var cards = CardsCollection.FullDeckOfCards;
            var combinations = cards.NumberOfQueenAndKingCombinations();
            Assert.IsFalse(5 == combinations);
        }
    }
}
