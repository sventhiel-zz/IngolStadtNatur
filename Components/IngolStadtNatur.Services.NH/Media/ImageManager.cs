using IngolStadtNatur.Entities.NH.Media;
using IngolStadtNatur.Persistence.NH;
using IngolStadtNatur.Services.Api.Objects;
using System.Collections.Generic;
using System.Linq;

namespace IngolStadtNatur.Services.NH.Media
{
    public class ImageManager : IImageManager
    {
        public ImageManager()
        {
            ImageRepository = new Repository<Image>();
        }

        public Repository<Image> ImageRepository { get; set; }
        public IQueryable<Image> Images => ImageRepository.Query();

        public void Create(Image image)
        {
            ImageRepository.Add(image);
        }

        public void Delete(Image image)
        {
            ImageRepository.Remove(image);
        }

        public Image FindById(long id)
        {
            return ImageRepository.Get(id);
        }

        public Image FindByName(string name)
        {
            return Images.FirstOrDefault(m => m.Name.ToUpper() == name.ToUpper());
        }

        public List<Image> Get(string[] names)
        {
            return names.Select(FindByName).ToList();
        }

        public void Update(Image image)
        {
            ImageRepository.Update(image);
        }
    }
}