using System.Collections.Generic;

namespace FakerDotNet.Data
{
    internal static class CommerceData
    {
        public static readonly IEnumerable<string> Departments = new[]
        {
            "Books",
            "Movies",
            "Music",
            "Games",
            "Electronics",
            "Computers",
            "Home",
            "Garden",
            "Tools",
            "Grocery",
            "Health",
            "Beauty",
            "Toys",
            "Kids",
            "Baby",
            "Clothing",
            "Shoes",
            "Jewelry",
            "Sports",
            "Outdoors",
            "Automotive",
            "Industrial"
        };

        public static readonly IEnumerable<string> ProductNames = new[]
        {
            "Chair",
            "Car",
            "Computer",
            "Gloves",
            "Pants",
            "Shirt",
            "Table",
            "Shoes",
            "Hat",
            "Plate",
            "Knife",
            "Bottle",
            "Coat",
            "Lamp",
            "Keyboard",
            "Bag",
            "Bench",
            "Clock",
            "Watch",
            "Wallet"
        };

        public static readonly IEnumerable<string> ProductAdjectives = new[]
        {
            "Small",
            "Ergonomic",
            "Rustic",
            "Intelligent",
            "Gorgeous",
            "Incredible",
            "Fantastic",
            "Practical",
            "Sleek",
            "Awesome",
            "Enormous",
            "Mediocre",
            "Synergistic",
            "Heavy Duty",
            "Lightweight",
            "Aerodynamic",
            "Durable"
        };

        public static readonly IEnumerable<string> Materials = new[]
        {
            "Steel",
            "Wooden",
            "Concrete",
            "Plastic",
            "Cotton",
            "Granite",
            "Rubber",
            "Leather",
            "Silk",
            "Wool",
            "Linen",
            "Marble",
            "Iron",
            "Bronze",
            "Copper",
            "Aluminum",
            "Paper"
        };

        public static readonly IEnumerable<string> PromotionCodeAdjectives = new[]
        {
            "Amazing",
            "Awesome",
            "Cool",
            "Good",
            "Great",
            "Incredible",
            "Killer",
            "Premium",
            "Special",
            "Stellar",
            "Sweet"
        };

        public static readonly IEnumerable<string> PromotionCodeNouns = new[]
        {
            "Code",
            "Deal",
            "Discount",
            "Price",
            "Promo",
            "Promotion",
            "Sale",
            "Savings"
        };
    }
}
