using FluentNHibernate.Mapping;
using IngolStadtNatur.Entities.NH.Common;
using IngolStadtNatur.Entities.NH.Objects;
using System.Collections.Generic;

namespace IngolStadtNatur.Entities.NH.Media
{
    public class Image : BaseEntity
    {
        public virtual string Author { get; set; }
        public virtual string Description { get; set; }
        public virtual string License { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Node> Nodes { get; set; }
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
            HasManyToMany(m => m.Nodes)
                .Table("Nodes_Images")
                .Cascade.All()
                .Inverse();
            Map(m => m.Path);
            Map(m => m.Source);
        }
    }
}