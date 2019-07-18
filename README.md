# FakerDotNet

A .NET port of the Ruby [faker](https://github.com/stympy/faker) gem

[![Build status](https://ci.appveyor.com/api/projects/status/t0t75f9t4xanjfea/branch/master?svg=true)](https://ci.appveyor.com/project/mrstebo/fakerdotnet/branch/master)
[![Coverage Status](https://coveralls.io/repos/github/mrstebo/FakerDotNet/badge.svg?branch=master)](https://coveralls.io/github/mrstebo/FakerDotNet?branch=master)
[![NuGet Version](https://img.shields.io/nuget/v/FakerDotNet.svg)](https://www.nuget.org/packages/FakerDotNet/)

## Contents

- [Installing](#installing)
- [Usage](#usage)
- [Generators](#generators)
  - [Default](#default)
  - [Blockchain](#blockchain)
- [Contributing](#contributing)
- [Copyright](#copyright)
- [License](#license)

## Installing

```powershell
Install-Package FakerDotNet
```

## Usage

```cs
var firstName = Faker.Name.FirstName(); // John
var lastName = Faker.Name.LastName(); // Smith
```

## Generators

### Default

- [Faker.Address](doc/default/address.md)
- [Faker.Ancient](doc/default/ancient.md)
- [Faker.App](doc/default/app.md)
- [Faker.Avatar](doc/default/avatar.md)
- [Faker.Bank](doc/default/bank.md)
- [Faker.Beer](doc/default/beer.md)
- [Faker.Book](doc/default/book.md)
- [Faker.Boolean](doc/default/boolean.md)
- [Faker.Business](doc/default/business.md)
- [Faker.Cat](doc/default/cat.md)
- [Faker.ChuckNorris](doc/default/chuck_norris.md)
- [Faker.Coffee](doc/default/coffee.md)
- [Faker.Color](doc/default/color.md)
- [Faker.Commerce](doc/default/commerce.md)
- [Faker.Company](doc/default/company.md)
- [Faker.Compass](doc/default/compass.md)
- [Faker.Date](doc/default/date.md)
- [Faker.Demographic](doc/default/demographic.md)
- [Faker.DragonBall](doc/default/dragon_ball.md)
- [Faker.Educator](doc/default/educator.md)
- [Faker.Fake](doc/default/fake.md)
- [Faker.File](doc/default/file.md)
- [Faker.Fillmurray](doc/default/fillmurray.md)
- [Faker.Food](doc/default/food.md)
- [Faker.GameOfThrones](doc/default/game_of_thrones.md)
- [Faker.Hacker](doc/default/hacker.md)
- [Faker.HarryPotter](doc/default/harry_potter.md)
- [Faker.Hipster](doc/default/hipster.md)
- [Faker.Internet](doc/default/internet.md)
- [Faker.LordOfTheRings](doc/default/lord_of_the_rings.md)
- [Faker.Lorem](doc/default/lorem.md)
- [Faker.LoremFlickr](doc/default/lorem_flickr.md)
- [Faker.LoremPixel](doc/default/lorem_pixel.md)
- [Faker.Matz](doc/default/matz.md)
- [Faker.MichaelScott](doc/default/michael_scott.md)
- [Faker.Music](doc/default/music.md)
- [Faker.Name](doc/default/name.md)
- [Faker.Number](doc/default/number.md)
- [Faker.PhoneNumber](doc/default/phone_number.md)
- [Faker.Placeholdit](doc/default/placeholdit.md)
- [Faker.Pokemon](doc/default/pokemon.md)
- [Faker.Random](doc/default/random.md)
- [Faker.RickAndMorty](doc/default/rick_and_morty.md)
- [Faker.RockBand](doc/default/rockband.md)
- [Faker.RuPaul](doc/default/rupaul.md)
- [Faker.SlackEmoji](doc/default/slackemoji.md)
- [Faker.Space](doc/default/space.md)
- [Faker.StarWars](doc/default/star_wars.md)
- [Faker.Superhero](doc/default/superhero.md)
- [Faker.Team](doc/default/team.md)
- [Faker.Time](doc/default/time.md)
- [Faker.TwinPeaks](doc/default/twin_peaks.md)
- [Faker.University](doc/default/university.md)
- [Faker.Vehicle](doc/default/vehicle.md)
- [Faker.Zelda](doc/default/zelda.md)

### Blockchain

- [Faker.Blockchain.Bitcoin](doc/blockchain/bitcoin.md)

## Contributing

There are many ways you can contribute to FakerDotNet. Like most open-source software projects, contributing code is just one of many outlets where you can help improve. Some of the things that you could help out with in FakerDotNet are:

- Documentation
- Bug reports
- Bug fixes
- Feature requests
- Feature implementations
- Test coverage
- Code quality

## Copyright

Copyright © 2018 Steven Atkinson and contributors

## License

FakerDotNet is licensed under MIT. Refer to [LICENSE](LICENSE) for more information.
