using System;
using System.Collections.Generic;
using System.Text;
using FakeItEasy;
using FakerDotNet.Data;
using FakerDotNet.Fakers;
using NUnit.Framework;

namespace FakerDotNet.Tests.Fakers
{
    [TestFixture]
    [Parallelizable]
    public class SlackEmojiFakerTests
    {
        [SetUp]
        public void SetUp()
        {
            _fakerContainer = A.Fake<IFakerContainer>();
            _slackEmojiFaker = new SlackEmojiFaker(_fakerContainer);

            A.CallTo(() => _fakerContainer.Fake).Returns(new FakeFaker(_fakerContainer));
        }

        private IFakerContainer _fakerContainer;
        private ISlackEmojiFaker _slackEmojiFaker;

        [Test]
        public void People_returns_a_person()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SlackEmojiData.People))
                .Returns(":sleepy:");

            Assert.AreEqual(":sleepy:", _slackEmojiFaker.People());
        }

        [Test]
        public void Nature_returns_a_nature()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SlackEmojiData.Nature))
                .Returns(":chestnut:");

            Assert.AreEqual(":chestnut:", _slackEmojiFaker.Nature());
        }

        [Test]
        public void FoodAndDrink_returns_a_foodanddrink()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SlackEmojiData.FoodAndDrink))
                .Returns(":tangerine:");

            Assert.AreEqual(":tangerine:", _slackEmojiFaker.FoodAndDrink());
        }

        [Test]
        public void Celebration_returns_a_celebration()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SlackEmojiData.Celebration))
                .Returns(":ribbon:");

            Assert.AreEqual(":ribbon:", _slackEmojiFaker.Celebration());
        }

        [Test]
        public void Activity_returns_an_activity()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SlackEmojiData.FoodAndDrink))
                .Returns(":performing_arts:");

            Assert.AreEqual(":performing_arts:", _slackEmojiFaker.FoodAndDrink());
        }

        [Test]
        public void TravelAndPlaces_returns_a_travelandplace()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SlackEmojiData.TravelAndPlaces))
                .Returns(":truck:");

            Assert.AreEqual(":truck:", _slackEmojiFaker.TravelAndPlaces());
        }

        [Test]
        public void ObjectAndSymbols_returns_an_objectandsymbol()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SlackEmojiData.Activity))
                .Returns(":alarm_clock:");

            Assert.AreEqual(":alarm_clock:", _slackEmojiFaker.Activity());
        }

        [Test]
        public void Custom_returns_a_custom()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SlackEmojiData.Custom))
                .Returns(":suspect:");

            Assert.AreEqual(":suspect:", _slackEmojiFaker.Custom());
        }

        [Test]
        public void Emoji_returns_an_emoji()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SlackEmojiData.Emoji))
                .Returns("#{nature}");
            A.CallTo(() => _fakerContainer.SlackEmoji.Nature())
                .Returns(":last_quarter_moon:");

            Assert.AreEqual(":last_quarter_moon:", _slackEmojiFaker.Emoji());
        }
    }
}
