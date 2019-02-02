# Faker.File

```cs
Faker.File.Extension() //=> "mp3"

Faker.File.MimeType() //=> "application/pdf"

# Optional arguments: dir, name, extension, directory_separator
Faker.File.FileName() //=> "my-path/something_random.jpg"
Faker.File.FileName("path/to") //=> "path/to/something_random.jpg"
Faker.File.FileName("foo/bar", "baz") //=> "foo/bar/baz.zip"
Faker.File.FileName("foo/bar", "baz", "doc") //=> "foo/bar/baz.doc"
Faker.File.FileName("foo/bar", "baz", "mp3", @"\") //=> "foo\bar\baz.mp3"
