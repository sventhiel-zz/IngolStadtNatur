using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace IngolStadtNatur.Entities.NH.Objects
{
    public class Species : Node
    {
        public virtual ICollection<Image> Images { get; set; }
    }

    public class SpeciesMap : SubclassMap<Species>
    {
        public SpeciesMap()
        {
            Table("Species");

            HasManyToMany(m => m.Images)
                .Table("Images_Species")
                .Cascade.All();
        }
    }
}
