using IngolStadtNatur.Entities.NH.Media;
using System.Configuration;

namespace IngolStadtNatur.Web.Shell.Models
{
    public class GalleryItemModel
    {
        public string Path { get; set; }

        public static GalleryItemModel Convert(Shot shot)
        {
            return new GalleryItemModel()
            {
                Path = System.IO.Path.Combine(ConfigurationManager.AppSettings["Shots"], shot.Name)
            };
        }
    }
}