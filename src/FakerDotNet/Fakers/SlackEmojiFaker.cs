using FakerDotNet.Data;
using System;
using System.Collections.Generic;
using System.Text;

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
        string ObjectAndSymbols();
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

        public string Activity()
        {
            return _fakerContainer.Random.Element(SlackEmojiData.Activity);
        }

        public string Celebration()
        {
            return _fakerContainer.Random.Element(SlackEmojiData.Celebration);
        }

        public string Custom()
        {
            return _fakerContainer.Random.Element(SlackEmojiData.Custom);
        }

        public string Emoji()
        {
            throw new NotImplementedException();
        }

        public string FoodAndDrink()
        {
            return _fakerContainer.Random.Element(SlackEmojiData.FoodAndDrink);
        }

        public string Nature()
        {
            return _fakerContainer.Random.Element(SlackEmojiData.Nature);
        }

        public string ObjectAndSymbols()
        {
            return _fakerContainer.Random.Element(SlackEmojiData.ObjectsAndSymbols);
        }

        public string People()
        {
            return _fakerContainer.Random.Element(SlackEmojiData.People);
        }

        public string TravelAndPlaces()
        {
            return _fakerContainer.Random.Element(SlackEmojiData.TravelAndPlaces);
        }
    }
}
