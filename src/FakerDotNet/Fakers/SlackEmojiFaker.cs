using FakerDotNet.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FakerDotNet.Fakers
{
    public interface ISlackEmojiFaker
    {
        string People();
        string Nature();
        string FoodAndDrink();
        string Celebration();
        string Activity();
        string TravelAndPlaces();
        string ObjectsAndSymbols();
        string Custom();
        string Emoji();
    }

    internal class SlackEmojiFaker : ISlackEmojiFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public SlackEmojiFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string People()
        {
            return _fakerContainer.Random.Element(SlackEmojiData.People);
        }

        public string Nature()
        {
            return _fakerContainer.Random.Element(SlackEmojiData.Nature);
        }

        public string FoodAndDrink()
        {
            return _fakerContainer.Random.Element(SlackEmojiData.FoodAndDrink);
        }

        public string Celebration()
        {
            return _fakerContainer.Random.Element(SlackEmojiData.Celebration);
        }

        public string Activity()
        {
            return _fakerContainer.Random.Element(SlackEmojiData.Activity);
        }

        public string TravelAndPlaces()
        {
            return _fakerContainer.Random.Element(SlackEmojiData.TravelAndPlaces);
        }

        public string ObjectsAndSymbols()
        {
            return _fakerContainer.Random.Element(SlackEmojiData.ObjectsAndSymbols);
        }

        public string Custom()
        {
            return _fakerContainer.Random.Element(SlackEmojiData.Custom);
        }

        public string Emoji()
        {
            return Parse(_fakerContainer.Random.Element(SlackEmojiData.Emoji));
        }

        private string Parse(string format)
        {
            var text = Regex.Replace(format, @"\{(\w+)\}", @"{SlackEmoji.$1}");

            return _fakerContainer.Fake.F(text);
        }
    }
}
