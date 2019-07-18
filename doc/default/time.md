# Faker.Time

```cs
// Random date between dates
Faker.Time.Between(new DateTime(2014, 9, 1), new DateTime(2014, 9, 30)) //=> "2014-09-18 12:30:59 -0700"

// Random date between dates (within specified part of the day)
Faker.Time.Between(new DateTime(2014, 9, 1), new DateTime(2014, 9, 30), TimePeriod.All) //=> "2014-09-19 07:03:30 -0700"
Faker.Time.Between(new DateTime(2014, 9, 1), new DateTime(2014, 9, 30), TimePeriod.Day) //=> "2014-09-18 16:28:13 -0700"
Faker.Time.Between(new DateTime(2014, 9, 1), new DateTime(2014, 9, 30), TimePeriod.Night) //=> "2014-09-20 19:39:38 -0700"
Faker.Time.Between(new DateTime(2014, 9, 1), new DateTime(2014, 9, 30), TimePeriod.Morning) //=> "2014-09-19 08:07:52 -0700"
Faker.Time.Between(new DateTime(2014, 9, 1), new DateTime(2014, 9, 30), TimePeriod.Afternoon) //=> "2014-09-18 12:10:34 -0700"
Faker.Time.Between(new DateTime(2014, 9, 1), new DateTime(2014, 9, 30), TimePeriod.Evening) //=> "2014-09-19 20:21:03 -0700"
Faker.Time.Between(new DateTime(2014, 9, 1), new DateTime(2014, 9, 30), TimePeriod.Midnight) //=> "2014-09-20 00:40:14 -0700"

// Random time in the future (up to maximum of N days)
Faker.Time.Forward(23, TimePeriod.Morning) //=> "2014-09-26 06:54:47 -0700"

// Random time in the past (up to maximum of N days)
Faker.Time.Backward(14, TimePeriod.Evening) //=> "2014-09-17 19:56:33 -0700"
```