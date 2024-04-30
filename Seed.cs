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
            string folderPath = "./Cereal pictures";

            // Get file paths of all images in the folder
            string[] imageFilePaths = Directory.GetFiles(folderPath, "*");

            // Create a list to store image objects
            List<Image> imagesToAdd = new List<Image>();

            // Add the cerealImage objects to the list
            foreach (var imagePath in imageFilePaths)
            {
                // Convert the image file to base64 string
                string base64String = ImageToBase64(imagePath);

                // Create a new Image object with the base64 string
                var image = new Image
                {
                    ImageBase64String = base64String,
                    CerealId = imagesToAdd.Count + 1
                };

                // Add the image object to the list
                imagesToAdd.Add(image);
            }

            // Add images to the database context
            _dataContext.Images.AddRange(imagesToAdd);

            // Save changes to the database
            _dataContext.SaveChanges();

            Console.WriteLine("Database populated with image base64 strings.");
        }

        // Method to convert image file to base64 string
        private string ImageToBase64(string imagePath)
        {
            // Read the image file into a byte array
            byte[] imageData = File.ReadAllBytes(imagePath);

            // Convert the byte array to a base64 string
            string base64String = Convert.ToBase64String(imageData);

            // Construct the data URI string with appropriate MIME type
            string mimeType = GetMimeType(imagePath);
            string dataUri = $"data:{mimeType};base64,{base64String}";

            return dataUri;
        }

        // Method to get MIME type based on file extension
        private string GetMimeType(string imagePath)
        {
            string extension = Path.GetExtension(imagePath).ToLower();
            switch (extension)
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                default:
                    throw new NotSupportedException($"File format {extension} is not supported.");
            }
        }
    }
}
