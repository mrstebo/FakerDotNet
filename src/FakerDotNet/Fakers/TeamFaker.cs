using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface ITeamFaker
    {
        string Creature();
        string Name();
        string State();
        string Sport();
        string Mascot();
    }

    internal class TeamFaker : ITeamFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public TeamFaker(IFakerContainer faker)
        {
            this._fakerContainer = faker;
        }

        public string Creature()
        {
            return _fakerContainer.Random.Element(TeamData.Creatures);
        }

        public string Name()
        {
            return State() + " " + Creature();
        }

        public string State()
        {
            return _fakerContainer.Address.State();
        }

        public string Sport()
        {
            return _fakerContainer.Random.Element(TeamData.Sports);
        }

        public string Mascot()
        {
            return _fakerContainer.Random.Element(TeamData.Mascots);
        }
    }
}
