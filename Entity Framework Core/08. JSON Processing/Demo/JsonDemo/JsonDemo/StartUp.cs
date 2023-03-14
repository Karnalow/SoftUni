using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonDemo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var car = new Car
            {
                Extras = new List<string> { "Klimatronik", "Quattro", "Farove" },
                ManufacturedOn = DateTime.Now,
                Model = "A4",
                Vendor = "Audi",
                Price = 5000.50M,
                Engine = new Engine { Volume = 2.5F, HorsePower = 180 }
            };

            //File.WriteAllText("myCar.json", JsonSerializer.Serialize(car));

            //var options = new JsonSerializerOptions
            //{
            //    WriteIndented = true
            //};

            //Console.WriteLine(JsonSerializer.Serialize(car, options));

            //var json = File.ReadAllText("myCar.json");
            //
            //var car = JsonSerializer.Deserialize<Car>(json);

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new DefaultNamingStrategy()
                }
            };

            Console.WriteLine(JsonConvert.SerializeObject(car, settings));
        }
    }
}