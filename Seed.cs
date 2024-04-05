using CerealAPI.Data;
using CerealAPI.Models;

namespace CerealAPI
{
    public class Seed
    {
        private readonly DataContext _dataContext;

        public Seed(DataContext context)
        {
            this._dataContext = context;
        }

        public void SeedDataContext()
        {
            // Check if database already has data
            if (_dataContext.Cereals.Any())
            {
                Console.WriteLine("Database already seeded.");
                return;
            }

            // Read the CSV file
            string csvFilePath = "./Cereal.csv";
            string[] csvLines = File.ReadAllLines(csvFilePath);

            foreach (var csvLine in csvLines.Skip(2)) // Skip header line
            {
                // Parse CSV line into Cereal object
                var csvValues = csvLine.Split(';');
                var cereal = new Cereal
                {
                    Name = csvValues[0],
                    Manufacturer = csvValues[1],
                    Type = csvValues[2],
                    Calories = int.Parse(csvValues[3]),
                    Protein = int.Parse(csvValues[4]),
                    Fat = int.Parse(csvValues[5]),
                    Sodium = int.Parse(csvValues[6]),
                    Fiber = float.Parse(csvValues[7]),
                    Carbohydrates = float.Parse(csvValues[8]),
                    Sugars = int.Parse(csvValues[9]),
                    Potassium = int.Parse(csvValues[10]),
                    Vitamins = int.Parse(csvValues[11]),
                    Shelf = int.Parse(csvValues[12]),
                    Weight = float.Parse(csvValues[13]),
                    Cups = float.Parse(csvValues[14]),
                    Rating = csvValues[15]
                };

                // Add Cereal object to database context
                _dataContext.Cereals.Add(cereal);
            }

            // Save changes to the database
            _dataContext.SaveChanges();

            Console.WriteLine("Database seeded successfully.");
        }
    }
}
