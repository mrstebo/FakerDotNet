# FakerDotNet

A .NET port of the Ruby [faker](https://github.com/stympy/faker) gem

[![Build status](https://ci.appveyor.com/api/projects/status/t0t75f9t4xanjfea/branch/master?svg=true)](https://ci.appveyor.com/project/mrstebo/fakerdotnet/branch/master)
[![Coverage Status](https://coveralls.io/repos/github/mrstebo/FakerDotNet/badge.svg?branch=master)](https://coveralls.io/github/mrstebo/FakerDotNet?branch=master)
[![NuGet Version](https://img.shields.io/nuget/v/FakerDotNet.svg)](https://www.nuget.org/packages/FakerDotNet/)

Contents
--------

- [Installing](#installing)
- [Usage](#usage)
  - [Faker.App](doc/app.md)
  - [Faker.Book](doc/book.md)
  - [Faker.Fake](doc/fake.md)
  - [Faker.Name](doc/name.md)
  - [Faker.Number](doc/number.md)
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
