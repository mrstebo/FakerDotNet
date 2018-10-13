using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IFriendsFaker
    {
        string Character();
        string Location();
        string Quote();
    }

    internal class FriendsFaker : IFriendsFaker
    {
        private static readonly FriendsData Data = new FriendsData();

        private readonly IFakerContainer _fakerContainer;

        public FriendsFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Character()
        {
            return _fakerContainer.Random.Element(Data.Characters);
        }

        public string Location()
        {
            return _fakerContainer.Random.Element(Data.Locations);
        }

        public string Quote()
        {
            return _fakerContainer.Random.Element(Data.Quotes);
        }
    }
}
