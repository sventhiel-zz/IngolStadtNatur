using IngolStadtNatur.Entities.NH.Objects;
using System.Collections.Generic;
using System.Linq;

namespace IngolStadtNatur.Web.Shell.Models
{
    public class CategoryListGroupModel
    {
        public ICollection<long> Children { get; set; }
        public string CommonName { get; set; }
        public string Description { get; set; }
        public long Id { get; set; }
        public List<ImageModel> Images { get; set; }
        public long ParentId { get; set; }
        public string Preview { get; set; }
        public string ScientificName { get; set; }
        public string UncertaintyHeader { get; set; }
        public string UncertaintyText { get; set; }

        public CategoryListGroupModel()
        {
            Children = new List<long>();
        }

        public static CategoryListGroupModel Convert(Category category)
        {
            return new CategoryListGroupModel()
            {
                Children = category.Children.Where(m => m.IsValid).OrderBy(m => m.GetType() == typeof(Category) ? 0 : 1).ThenBy(m => m.CommonName).Select(m => m.Id).ToList(),
                CommonName = category.CommonName,
                Description = category.Description,
                Id = category.Id,
                ParentId = category.Parent?.Id ?? 0,
                Preview = category.Preview,
                ScientificName = category.ScientificName,
                UncertaintyHeader = category.UncertaintyHeader,
                UncertaintyText = category.UncertaintyText
            };
        }
    }

    public class CategoryListGroupItemModel
    {
        public string Description { get; set; }
        public long Id { get; set; }
        public List<ImageListGroupItemModel> Images { get; set; }
        public string CommonName { get; set; }
        public string Preview { get; set; }
        public string ScientificName { get; set; }

        public static CategoryListGroupItemModel Convert(Category category)
        {
            return new CategoryListGroupItemModel()
            {
                Description = category.Description,
                Id = category.Id,
                CommonName = category.CommonName,
                Preview = category.Preview,
                ScientificName = category.ScientificName
            };
        }
    }

    public class CategoryModel
    {
        public string CommonName { get; set; }
        public string Description { get; set; }
        public long Id { get; set; }
        public List<ImageModel> Images { get; set; }
        public string Reference { get; set; }
        public string ScientificName { get; set; }

        public static CategoryModel Convert(Category category)
        {
            return new CategoryModel()
            {
                CommonName = category.CommonName,
                Description = category.Description,
                Id = category.Id,
                Reference = category.Reference,
                ScientificName = category.ScientificName,
            };
        }
    }
}