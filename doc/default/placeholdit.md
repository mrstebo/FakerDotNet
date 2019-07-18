# Faker.Placeholdit

```cs
Faker.Placeholdit.Image() //=> "https://placehold.it/300x300.png"

Faker.Placeholdit.Image("50x50") //=> "https://placehold.it/50x50.png"

Faker.Placeholdit.Image("50x50", "jpg") //=> "https://placehold.it/50x50.jpg"

Faker.Placeholdit.Image("50x50", "gif", "ffffff") //=> "https://placehold.it/50x50.gif/ffffff"

Faker.Placeholdit.Image("50x50", "jpeg", RandomColor.Value) //=> "https://placehold.it/50x50.jpeg/39eba7"

Faker.Placeholdit.Image("50x50", "jpeg", "ffffff", "000") //=> "https://placehold.it/50x50.jpeg/ffffff/000"

Faker.Placeholdit.Image("50x50", "jpeg", RandomColor.Value, RandomColor.Value) //=> "https://placehold.it/50x50.jpeg/d39e44/888ba7"

Faker.Placeholdit.Image("50x50", "jpg", "ffffff", "000", "Some Custom Text") //=> "https://placehold.it/50x50.jpg/ffffff/000?text=Some Custom Text"
```
