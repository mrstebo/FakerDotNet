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
        private readonly IFakerContainer _fakerContainer;

        public FriendsFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Character()
        {
            return _fakerContainer.Random.Element(FriendsData.Characters);
        }

        public string Location()
        {
            return _fakerContainer.Random.Element(FriendsData.Locations);
        }

        public string Quote()
        {
            return _fakerContainer.Random.Element(FriendsData.Quotes);
        }
    }
}
