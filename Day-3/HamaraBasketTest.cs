using hamaraBasket.Tests;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Collections.Generic;

namespace hamaraBasket
{
    [TestFixture]
    public class HamaraBasketTest
    {
        DomainFactory domainFactory;

        public List<Item> CreateSingleItem(string name, int sellIn, int quality)
        {
            return domainFactory.CreateSingleItem(name, sellIn, quality);
        }

        public void UpdateQuality(IList<Item> items)
        {
            domainFactory.UpdateQuality(items);
        }
          

        [SetUp]
        public void Setup()
        {
            domainFactory = new DomainFactory();
        }

        [TestCase("product1", 10, 10)]
        [TestCase("product2", 5, 10)]
        public void WhenUpdateQualityIsCalled_ThenQualityDecreasesByOne(string productName, int sellIn, int quality)
        {
            IList<Item> items = CreateSingleItem(productName, sellIn, quality);
            UpdateQuality(items);
            Assert.That(items[0].Quality, Is.EqualTo(quality - 1));
        }

        [TestCase("product1", 10, 10)]
        [TestCase("product2", 5, 10)]
        public void WhenUpdateQualityIsCalled_ThenSellInValueDecreasesByOne(string productName, int sellIn, int quality)
        {
            IList<Item> items = CreateSingleItem(productName, sellIn, quality);
            UpdateQuality(items);
            Assert.That(items[0].SellIn, Is.EqualTo(sellIn - 1));
        }

        [TestCase("product1", -1, 10)]
        [TestCase("product2", -5, 10)]
        public void GivenSellDateHasPassedWhenUpdateQualityIsCalled_ThenQualityDecreasesByTwo(string productName, int sellIn, int quality)
        {
            IList<Item> items = CreateSingleItem(productName, sellIn, quality);
            UpdateQuality(items);
            Assert.That(items[0].Quality, Is.EqualTo(quality - 2));
        }

        [TestCase("product1", -1, 0)]
        [TestCase("product2", -5, 0)]
        public void WhenUpdateQualityIsCalled_ThenQualityShouldNeverReachNegativeValue(string productName, int sellIn, int quality)
        {
            IList<Item> items = CreateSingleItem(productName, sellIn, quality);
            UpdateQuality(items);
            Assert.That(items[0].Quality, Is.EqualTo(0));
        }

        [TestCase("Indian Wine", 1, 10)]
        [TestCase("Indian Wine", 5, 0)]
        public void WhenUpdateQualityIsCalled_ThenIndianWineProductIncreasesInQuality(string productName, int sellIn, int quality)
        {
            IList<Item> items = CreateSingleItem(productName, sellIn, quality);
            UpdateQuality(items);
            Assert.That(items[0].Quality, Is.EqualTo(quality + 1));
        }

        [TestCase("Indian Wine", 1, 50)]
        [TestCase("Forest Honey", 5, 50)]
        [TestCase("Indian Wine", 5, 50)]
        public void GivenSellInIsPositive_WhenUpdateQualityIsCalled_ThenQualityDoesntReachMoreThan50(string productName, int sellIn, int quality)
        {
            IList<Item> items = CreateSingleItem(productName, sellIn, quality);
            UpdateQuality(items);
            Assert.That(items[0].Quality, Is.EqualTo(50));
        }

        [TestCase("Indian Wine", -1, 50)]
        [TestCase("Forest Honey", -2, 50)]
        [TestCase("Indian Wine", -10, 50)]
        public void GivenSellInIsNegative_WhenUpdateQualityIsCalled_ThenQualityDoesntReachMoreThan50(string productName, int sellIn, int quality)
        {
            IList<Item> items = CreateSingleItem(productName, sellIn, quality);
            UpdateQuality(items);
            Assert.That(items[0].Quality, Is.EqualTo(50));
        }

        [TestCase("Forest Honey", 1, 45)]
        public void WhenUpdateQualityIsCalled_ThenForestWineQualityStaysConstant(string productName, int sellIn, int quality)
        {
            IList<Item> items = CreateSingleItem(productName, sellIn, quality);
            UpdateQuality(items);
            Assert.That(items[0].Quality, Is.EqualTo(quality));
        }

        [TestCase("Forest Honey", 1, 45)]
        public void WhenUpdateQualityIsCalled_ThenForestWineSellInStaysConstant(string productName, int sellIn, int quality)
        {
            IList<Item> items = CreateSingleItem(productName, sellIn, quality);
            UpdateQuality(items);
            Assert.That(items[0].SellIn, Is.EqualTo(sellIn));
        }

        [TestCase("Movie Tickets", 11, 45)]
        public void WhenSellInDateIsMoreThan5DaysUpdateQualityIsCalled_ThenMovieTicketsIncreasesQualityByOne(string productName, int sellIn, int quality)
        {
            IList<Item> items = CreateSingleItem(productName, sellIn, quality);
            UpdateQuality(items);
            Assert.That(items[0].Quality, Is.EqualTo(quality + 1));
        }

        [TestCase("Movie Tickets", 2, 45)]
        public void WhenSellInDateIsLessThan5DaysUpdateQualityIsCalled_ThenMovieTicketsIncreasesQualityByThree(string productName, int sellIn, int quality)
        {
            IList<Item> items = CreateSingleItem(productName, sellIn, quality);
            UpdateQuality(items);
            Assert.That(items[0].Quality, Is.EqualTo(quality + 3));
        }

        [TestCase("Movie Tickets", 0, 45)]
        [TestCase("Movie Tickets", -1, 45)]
        public void WhenSellInDateIsCrossedUpdateQualityIsCalled_ThenMovieTickeQualityReachesToZero(string productName, int sellIn, int quality)
        {
            IList<Item> items = CreateSingleItem(productName, sellIn, quality);
            UpdateQuality(items);
            Assert.That(items[0].Quality, Is.EqualTo(0));
        }
    }
}
