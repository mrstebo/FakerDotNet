# Faker.Internet

```cs
// Optional arguments name=null, *separators
Faker.Internet.Email() //=> "eliza@mann.net"

Faker.Internet.Email("Nancy") //=> "nancy@terry.biz"

Faker.Internet.Email("Janelle Santiago", "+") //=> janelle+santiago@becker.com"

// Optional argument name=null
Faker.Internet.FreeEmail() //=> "freddy@gmail.com"

Faker.Internet.FreeEmail("Nancy") //=> "nancy@yahoo.com"

// Optional argument name=null
Faker.Internet.SafeEmail() //=> "christelle@example.org"

Faker.Internet.SafeEmail("Nancy") //=> "nancy@example.net"

// Optional arguments specifier=null, separators=%w(. _)
Faker.Internet.Username() //=> "alexie"

Faker.Internet.Username("Nancy") //=> "nancy"

Faker.Internet.Username("Nancy Johnson", %w(. _ -)) //=> "johnson-nancy"

// Optional arguments: min_length=5, max_length=8
Faker.Internet.Username(new Range<int>(5, 8))

// Optional argument min_length=8
Faker.Internet.Username(8)

// Optional arguments: min_length=8, max_length=16
Faker.Internet.Password() //=> "Vg5mSvY1UeRg7"

Faker.Internet.Password(8) //=> "YfGjIk0hGzDqS0"

Faker.Internet.Password(10, 20) //=> "EoC9ShWd1hWq4vBgFw"

Faker.Internet.Password(10, 20, true) //=> "3k5qS15aNmG"

Faker.Internet.Password(10, 20, true, true) //=> "*%NkOnJsH4"

Faker.Internet.DomainName() //=> "effertz.info"

Faker.Internet.DomainWord() //=> "haleyziemann"

Faker.Internet.DomainSuffix() //=> "info"

Faker.Internet.IPv4Address() //=> "24.29.18.175"

// Private IP range according to RFC 1918 and 127.0.0.0/8 and 169.254.0.0/16.
Faker.Internet.PrivateIPv4Address() //=> "10.0.0.1"

// Guaranteed not to be in the ip range from the private_ip_v4_address method.
Faker.Internet.PublicIPv4Address() //=> "24.29.18.175"

Faker.Internet.IPv4Cidr() //=> "24.29.18.175/21"

Faker.Internet.IPv6Address() //=> "ac5f:d696:3807:1d72:2eb5:4e81:7d2b:e1df"

Faker.Internet.IPv6Cidr() //=> "ac5f:d696:3807:1d72:2eb5:4e81:7d2b:e1df/78"

// Optional argument prefix=""
Faker.Internet.MacAddress() //=> "e6:0d:00:11:ed:4f"
Faker.Internet.MacAddress("55:44:33") //=> "55:44:33:02:1d:9b"

// Optional arguments: host=domain_name, path="/#{username}", scheme=scheme
Faker.Internet.Url() //=> "http://thiel.com/chauncey_simonis"
Faker.Internet.Url("example.com") //=> "http://example.com/clotilde.swift"
Faker.Internet.Url("example.com", "/foobar.html") //=> "http://example.com/foobar.html"

// Optional arguments: words=null, glue=null
Faker.Internet.Slug() //=> "pariatur_laudantium"
Faker.Internet.Slug("foo bar") //=> "foo.bar"
Faker.Internet.Slug("foo bar", "-") //=> "foo-bar"

// Optional argument: vendor=null
Faker.Internet.UserAgent() //=> "Mozilla/5.0 (compatible; MSIE 9.0; AOL 9.7; AOLBuild 4343.19; Windows NT 6.1; WOW64; Trident/5.0; FunWebProducts)"
Faker.Internet.UserAgent(UserAgent.Firefox) //=> "Mozilla/5.0 (Windows NT x.y; Win64; x64; rv:10.0) Gecko/20100101 Firefox/10.0"
```