# Faker.Commerce

```cs
Faker.Commerce.Color() //=> "lavender"

# Optional arguments max=3, fixedAmount=false
Faker.Commerce.Department() //=> "Grocery, Health & Beauty"
Faker.Commerce.Department(5) //=> "Grocery, Books, Health & Beauty"
Faker.Commerce.Department(2, true) //=> "Books & Tools"

Faker.Commerce.Material() //=> "Steel"

Faker.Commerce.ProductName() //=> "Practical Granite Shirt"

Faker.Commerce.Price() //=> "44.6"
Faker.Commerce.Price(mew Range<double>(0, 10)) //=> "2.18"

# Generate a random promotion code.
# Optional argument digits = 6 for number of random digits in suffix
Faker.Commerce.PromotionCode() //=> "AmazingDeal829102"
Faker.Commerce.PromotionCode(digits = 2) //=> "AmazingPrice57"
```