# Faker.Date

```cs
// Random date between dates
Faker.Date.Between(new DateTime(2014, 9, 1), new DateTime(2014, 9, 30)) //=> "Wed, 24 Sep 2014"
Faker.Date.Between("2014-09-01", "2014-09-30") //=> "Wed, 24 Sep 2014"

// Random date between dates except for certain date
Faker.Date.BetweenExcept(new DateTime(2014, 9, 1), new DateTime(2015, 9, 1), DateTime.UtcNow) //=> "Wed, 24 Sep 2014"
Faker.Date.BetweenExcept("2014-01-01", "2015-01-30")

// Random date in the future (up to maximum of N days)
Faker.Date.Forward(23) //=> "Fri, 03 Oct 2014"

// Random date in the past (up to maximum of N days)
Faker.Date.Backward(14) //=> "Fri, 19 Sep 2014"

// Random birthday date (maximum age between 18 and 65)
Faker.Date.Birthday(18, 65) //=> "Fri, 28 Mar 1986"
```