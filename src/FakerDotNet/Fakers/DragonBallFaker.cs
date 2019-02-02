using FakerDotNet.Data;
using System;

namespace FakerDotNet.Fakers
{
    public interface IDragonBallFaker
    {
        string Character();
    }

    internal class DragonBallFaker : IDragonBallFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public DragonBallFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Character()
        {
            return _fakerContainer.Random.Element(DragonBallData.Characters);
        }
    }
}
