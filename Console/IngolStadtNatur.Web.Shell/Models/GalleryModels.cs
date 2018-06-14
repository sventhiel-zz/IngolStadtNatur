using IngolStadtNatur.Entities.NH.Media;

namespace IngolStadtNatur.Web.Shell.Models
{
    public class GalleryItemModel
    {
        public string Name { get; set; }

        public static GalleryItemModel Convert(Shot shot)
        {
            return new GalleryItemModel()
            {
                Name = shot.Name
            };
        }
    }
}