# Faker.Vehicle

```cs
Faker.Vehicle.Vin() //=> "LLDWXZLG77VK2LUUF"

# Random vehicle manufacturer
Faker.Vehicle.Manufacture() //=> "Lamborghini"
Faker.Vehicle.Make() //=> "Honda"

# Random vehicle model
Faker.Vehicle.Model() //=> "A8"
Faker.Vehicle.Make() //=> "Honda"
Faker.Vehicle.Make("Toyota") //=> "Prius"
Faker.Vehicle.MakeAndModel() //=> "Dodge Charger"

# Random vehicle color
Faker.Vehicle.Color() //=> "Red"

# Random vehicle transmission
Faker.Vehicle.Transmission() //=> "Automanual"

# Random vehicle drive type
Faker.Vehicle.DriveType() //=> "4x2/2-wheel drive"

# Random vehicle fuel type
Faker.Vehicle.FuelType() //=> "Diesel"

# Random vehicle style
Faker.Vehicle.VehicleStyle() //=> "ESi"

# Random car type
Faker.Vehicle.CarType() //=> "Sedan"

# Random car options
Faker.Vehicle.CarOptions() //=> "["DVD System", "MP3 (Single Disc)", "Tow Package", "CD (Multi Disc)", "Cassette Player", "Bucket Seats", "Cassette Player", "Leather Interior", "AM/FM Stereo", "Third Row Seats"]"

# Random standard car specs
Faker.Vehicle.StandardSpecs() //=> "["Full-size spare tire w/aluminum alloy wheel", "Back-up camera", "Carpeted cargo area", "Silver accent IP trim finisher -inc: silver shifter finisher", "Back-up camera", "Water-repellent windshield & front door glass", "Floor carpeting"]"

# Random number of doors
Faker.Vehicle.Doors() //=> 1
Faker.Vehicle.DoorCount() //=> 3

# Random engine size
Faker.Vehicle.EngineSize() //=> 6
Faker.Vehicle.Engine() //=> 4

# Random car year
# Between 1 and 15 years ago
Faker.Vehicle.Year() //=> 2008

# Random mileage/kilometrage
Faker.Vehicle.Mileage() //=> 26961
Faker.Vehicle.Mileage(50000) //=> 81557
Faker.Vehicle.Mileage(50000, 250000) //=> 117503
Faker.Vehicle.Kilometers() //=> 35378

# Random vehicle license plate (USA Only)
Faker.Vehicle.LicensePlate() //=> "DEP-2483"
Faker.Vehicle.LicensePlate("FL") //=> "977 UNU"
```