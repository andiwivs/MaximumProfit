using NUnit.Framework;
using Thomas.MaximumProfit.Core;

namespace MazimumProfit.Test
{
    [TestFixture]
    [Category("ProfitEvaluator")]
    public class ProfitEvaluatorTests
    {

        ProfitEvaluator _evaluator;

        [SetUp]
        public void Setup()
        {
            _evaluator = new ProfitEvaluator();
        }

        [Test]
        [TestCase(null)]
        [TestCase(new int[0])]
        public void WhenNullOrEmptyReturnsZero(int[] prices)
        {
            // Arrange
            int maxProfit;

            // Act
            maxProfit = _evaluator.GetMaxProfit(prices);

            // Assert
            Assert.AreEqual(0, maxProfit);
        }

        [Test]
        public void WhenPriceRemainedConstantReturnZero()
        {
            // Arrange
            int maxProfit;
            int[] prices = new int[] { 1 };

            // Act
            maxProfit = _evaluator.GetMaxProfit(prices);

            // Assert
            Assert.AreEqual(0, maxProfit);
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(1, 2, 1)]
        [TestCase(2, 1, -1)]
        public void WhenPriceChangedOnceReturnDifference(int firstPrice, int secondPrice, int expectedProfit)
        {
            // Arrange
            int maxProfit;
            int[] prices = new int[] { firstPrice, secondPrice };

            // Act
            maxProfit = _evaluator.GetMaxProfit(prices);

            // Assert
            Assert.AreEqual(expectedProfit, maxProfit);
        }

        [Test]
        [TestCase(0, 0, 0, 0)]
        [TestCase(1, 2, 3, 2)]
        [TestCase(1, 2, 4, 3)]
        [TestCase(2, 1, 4, 3)]
        [TestCase(2, 1, 0, -1)]
        [TestCase(5, 3, 1, -2)]
        public void WhenPriceChangedTwiceReturnMaximumProfit(int firstPrice, int secondPrice, int thirdPrice, int expectedProfit)
        {
            // Arrange
            int maxProfit;
            int[] prices = new int[] { firstPrice, secondPrice, thirdPrice };

            // Act
            maxProfit = _evaluator.GetMaxProfit(prices);

            // Assert
            Assert.AreEqual(expectedProfit, maxProfit);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 0, 0, 0, 0, 0, 0, 0 }, 0)]
        [TestCase(new int[] { 1, 2, 0, -5, 10 }, 15)]
        [TestCase(new int[] { 10, 7, 5, 8, 11, 9 }, 6)]
        public void WhenPriceChangedMultipleTimesReturnMaximumProfit(int[] prices, int expectedProfit)
        {
            // Arrange
            int maxProfit;

            // Act
            maxProfit = _evaluator.GetMaxProfit(prices);

            // Assert
            Assert.AreEqual(expectedProfit, maxProfit);
        }
    }
}
