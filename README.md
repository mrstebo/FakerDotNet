# FakerDotNet

A .NET port of the Ruby [faker](https://github.com/stympy/faker) gem

Contents
--------

- [Installing](#installing)
- [Usage](#usage)
  - [Faker.Name](doc/name.md)
  - [Faker.Random](doc/random.md)

## Installing

```powershell
Install-Package FakerDotNet
```

## Usage

```cs
var firstName = Faker.Name.FirstName(); // John
var lastName = Faker.Name.LastName(); // Smith
```