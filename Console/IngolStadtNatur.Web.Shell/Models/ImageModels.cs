namespace IngolStadtNatur.Web.Shell.Models
{
    public class ImageListGroupItemModel
    {
        public string Description { get; set; }
        public string Name { get; set; }

        public static ImageListGroupItemModel Convert(Image image)
        {
            return new ImageListGroupItemModel()
            {
                Description = image.Description,
                Name = image.Name
            };
        }
    }

    public class ImageModel
    {
        public string Author { get; set; }
        public string Description { get; set; }
        public string License { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Source { get; set; }

        public static ImageModel Convert(Image image)
        {
            return new ImageModel()
            {
                Author = image.Author,
                Description = image.Description,
                License = image.License,
                Name = image.Name,
                Path = image.Path,
                Source = image.Source
            };
        }
    }
}