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
            A.CallTo(() => _fakerContainer.Random.Element(SlackEmojiData.Activity))
                .Returns(":performing_arts:");

            Assert.AreEqual(":performing_arts:", _slackEmojiFaker.Activity());
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
            A.CallTo(() => _fakerContainer.Random.Element(SlackEmojiData.ObjectsAndSymbols))
                .Returns(":alarm_clock:");

            Assert.AreEqual(":alarm_clock:", _slackEmojiFaker.ObjectsAndSymbols());
        }

        [Test]
        public void Custom_returns_a_custom()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SlackEmojiData.Custom))
                .Returns(":suspect:");

            Assert.AreEqual(":suspect:", _slackEmojiFaker.Custom());
        }

        [Test]
        public void Emoji_returns_an_emoji_people()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SlackEmojiData.Emoji))
                .Returns("{People}");
            A.CallTo(() => _fakerContainer.SlackEmoji.People())
                .Returns(":relieved:");

            Assert.AreEqual(":relieved:", _slackEmojiFaker.Emoji());
        }

        [Test]
        public void Emoji_returns_an_emoji_nature()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SlackEmojiData.Emoji))
                .Returns("{Nature}");
            A.CallTo(() => _fakerContainer.SlackEmoji.Nature())
                .Returns(":last_quarter_moon:");

            Assert.AreEqual(":last_quarter_moon:", _slackEmojiFaker.Emoji());
        }

        [Test]
        public void Emoji_returns_an_emoji_foodAndDrink()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SlackEmojiData.Emoji))
                .Returns("{FoodAndDrink}");
            A.CallTo(() => _fakerContainer.SlackEmoji.FoodAndDrink())
                .Returns(":ramen:");

            Assert.AreEqual(":ramen:", _slackEmojiFaker.Emoji());
        }

        [Test]
        public void Emoji_returns_an_emoji_Celebration()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SlackEmojiData.Emoji))
                .Returns("{Celebration}");
            A.CallTo(() => _fakerContainer.SlackEmoji.Celebration())
                .Returns(":collision:");

            Assert.AreEqual(":collision:", _slackEmojiFaker.Emoji());
        }

        [Test]
        public void Emoji_returns_an_emoji_Activity()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SlackEmojiData.Emoji))
                .Returns("{Activity}");
            A.CallTo(() => _fakerContainer.SlackEmoji.Activity())
                .Returns(":surfer:");

            Assert.AreEqual(":surfer:", _slackEmojiFaker.Emoji());
        }

        [Test]
        public void Emoji_returns_an_emoji_TravelAndPlaces()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SlackEmojiData.Emoji))
                .Returns("{TravelAndPlaces}");
            A.CallTo(() => _fakerContainer.SlackEmoji.TravelAndPlaces())
                .Returns(":oncoming_taxi:");

            Assert.AreEqual(":oncoming_taxi:", _slackEmojiFaker.Emoji());
        }

        [Test]
        public void Emoji_returns_an_emoji_ObjectsAndSymbols()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SlackEmojiData.Emoji))
                .Returns("{ObjectsAndSymbols}");
            A.CallTo(() => _fakerContainer.SlackEmoji.ObjectsAndSymbols())
                .Returns(":video_camera:");

            Assert.AreEqual(":video_camera:", _slackEmojiFaker.Emoji());
        }

        [Test]
        public void Emoji_returns_an_emoji_Customs()
        {
            A.CallTo(() => _fakerContainer.Random.Element(SlackEmojiData.Emoji))
                .Returns("{Custom}");
            A.CallTo(() => _fakerContainer.SlackEmoji.Custom())
                .Returns(":godmode:");

            Assert.AreEqual(":godmode:", _slackEmojiFaker.Emoji());
        }
    }
}
