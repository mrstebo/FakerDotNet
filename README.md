# FakerDotNet

A .NET port of the Ruby [faker](https://github.com/stympy/faker) gem

[![Build status](https://ci.appveyor.com/api/projects/status/t0t75f9t4xanjfea/branch/master?svg=true)](https://ci.appveyor.com/project/mrstebo/fakerdotnet/branch/master)
[![Coverage Status](https://coveralls.io/repos/github/mrstebo/FakerDotNet/badge.svg?branch=master)](https://coveralls.io/github/mrstebo/FakerDotNet?branch=master)
[![NuGet Version](https://img.shields.io/nuget/v/FakerDotNet.svg)](https://www.nuget.org/packages/FakerDotNet/)

Contents
--------

- [Installing](#installing)
- [Usage](#usage)
  - [Faker.Address](doc/address.md)
  - [Faker.App](doc/app.md)
  - [Faker.Book](doc/book.md)
  - [Faker.Boolean](doc/boolean.md)
  - [Faker.Business](doc/business.md)
  - [Faker.Date](doc/date.md)
  - [Faker.Fake](doc/fake.md)
  - [Faker.Lorem](doc/lorem.md)
  - [Faker.Name](doc/name.md)
  - [Faker.Number](doc/number.md)
  - [Faker.Pokemon](doc/pokemon.md)
  - [Faker.Random](doc/random.md)
  - [Faker.Time](doc/time.md)
  - [Faker.Zelda](doc/zelda.md)
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