using FakerDotNet.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakerDotNet.Fakers
{
    public interface IZeldaFaker
    {
        string Game();
        string Character();
        string Location();
        string Item();
    }

    internal class ZeldaFaker : IZeldaFaker
    {
        private static readonly ZeldaData Data = new ZeldaData();
        private readonly IFakerContainer _fakerContainer;

        public ZeldaFaker(IFakerContainer faker) => this._fakerContainer = faker;

        public string Character() => _fakerContainer.Random.Element(Data.Characters);

        public string Game() => _fakerContainer.Random.Element(Data.Games);

        public string Item() => _fakerContainer.Random.Element(Data.Items);

        public string Location() => _fakerContainer.Random.Element(Data.Locations);
    }
}
