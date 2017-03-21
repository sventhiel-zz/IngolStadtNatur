using IngolStadtNatur.Entities.NH.Objects;
using IngolStadtNatur.Persistence.NH;
using IngolStadtNatur.Services.Api.Objects;
using System.Collections.Generic;
using System.Linq;

namespace IngolStadtNatur.Services.NH.Objects
{
    public class ImageManager : IImageManager
    {
        public Repository<Image> ImageRepository { get; set; }

        public ImageManager()
        {
            ImageRepository = new Repository<Image>();
        }

        public IQueryable<Image> Images => ImageRepository.Query();


        public void Create(Image image)
        {
            ImageRepository.Add(image);
        }

        public void Delete(Image image)
        {
            ImageRepository.Remove(image);
        }

        public Image Get(long id)
        {
            return ImageRepository.Get(id);
        }

        public Image Get(string name)
        {
            return Images.FirstOrDefault(m => m.Name.ToUpper() == name.ToUpper());
        }

        public List<Image> Get(string[] names)
        {
            return null;
        }

        public void Update(Image image)
        {
            ImageRepository.Update(image);
        }
    }
}
