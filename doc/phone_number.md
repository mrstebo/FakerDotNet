# Faker.PhoneNumber

Phone numbers may be in any of the following formats:

  * 333-333-3333
  * (333) 333-3333
  * 1-333-333-3333
  * 333.333.3333
  * 333-333-3333
  * 333-333-3333 x3333
  * (333) 333-3333 x3333
  * 1-333-333-3333 x3333
  * 333.333.3333 x3333

(Don't let the example output below fool you - any format can be returned at random.)

```cs
Faker.PhoneNumber.PhoneNumber() //=> "397.693.1309"

Faker.PhoneNumber.CellPhone() //=> "(186)285-7925"

// NOTE NOTE NOTE NOTE
// For the 'US only' methods below, first you must do the following:
Faker.Config.locale = 'en-US'
// or for Canada
Faker.Config.locale = 'en-CA'

// US only
Faker.PhoneNumber.AreaCode() //=> "201"

// US only
Faker.PhoneNumber.ExchangeCode() //=> "208"

// Optional parameter: length=4
Faker.PhoneNumber.SubscriberNumber() //=> "3873"

Faker.PhoneNumber.SubscriberNumber(2) //=> "39"

Faker.PhoneNumber.Extension() //=> "3764"

Faker.PhoneNumber.Extension(2) //=> "36"
```
