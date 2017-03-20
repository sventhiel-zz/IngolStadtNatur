using FluentNHibernate.Mapping;
using IngolStadtNatur.Entities.NH.Common;
using System.Collections.Generic;

namespace IngolStadtNatur.Entities.NH.Objects
{
    public class Image : BaseEntity
    {
        public virtual string Author { get; set; }
        public virtual string Description { get; set; }
        public virtual string License { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Species> Species { get; set; }
        public virtual string Path { get; set; }
        public virtual string Source { get; set; }
    }

    public class ImageMap : ClassMap<Image>
    {
        public ImageMap()
        {
            Table("Images");

            Id(m => m.Id);
            Version(m => m.Version);

            Map(m => m.Author);
            Map(m => m.Description);
            Map(m => m.License);
            Map(m => m.Name);
            HasManyToMany(m => m.Species)
                .Table("Images_Species")
                .Cascade.All()
                .Inverse();
            Map(m => m.Path);
            Map(m => m.Source);
        }
    }
}
