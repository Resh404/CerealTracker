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
            // Check if the database already has data
            if (_dataContext.Cereals.Any())
            {
                Console.WriteLine("Database already seeded.");
                return;
            }

            // Read the CSV file
            string csvFilePath = "./Cereal.csv";
            string[] csvLines = File.ReadAllLines(csvFilePath);

            // Create a list to store cereal objects
            List<Cereal> cerealsToAdd = new List<Cereal>();

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

                // Add the cereal object to the list
                cerealsToAdd.Add(cereal);
            }

            // Sort the list of cereals alphabetically by name
            cerealsToAdd = cerealsToAdd.OrderBy(o => o.Name).ToList();

            // Add sorted cereals to the database context
            _dataContext.Cereals.AddRange(cerealsToAdd);

            // Save changes to the database
            _dataContext.SaveChanges();

            Console.WriteLine("Database seeded successfully.");
        }


        public void SeedImages()
        {
            string folderPath = @"C:\Users\KOM\Downloads\Cereal pictures\Cereal Pictures";

            // Get file paths of all images in the folder
            string[] imageFilePaths = Directory.GetFiles(folderPath, "*");

            // Create a list to store image objects
            List<Image> imagesToAdd = new List<Image>();
            int i = 1;

            // Add the cerealImage objects to the list
            foreach (var imagePath in imageFilePaths)
            {
                // Create a new Image object with the file path
                var image = new Image
                {
                    ImageFilePath = imagePath,
                    CerealId = i
                };

                // Add the image object to the list
                imagesToAdd.Add(image);
                i++;
            }

            // Sort the list of images alphabetically by file path
            imagesToAdd =imagesToAdd.OrderBy(o => o.ImageFilePath).ToList();

            // Add sorted images to the database context
            _dataContext.Images.AddRange(imagesToAdd);

            // Save changes to the database
            _dataContext.SaveChanges();

            Console.WriteLine("Database populated with image file paths.");
        }
    }
}
