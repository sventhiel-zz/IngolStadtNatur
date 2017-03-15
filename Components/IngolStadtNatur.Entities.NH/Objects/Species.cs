using FluentNHibernate.Mapping;

namespace IngolStadtNatur.Entities.NH.Objects
{
    public class Species : Node
    {

    }

    public class SpeciesMap : SubclassMap<Species>
    {
        public SpeciesMap()
        {
            Table("Species");
        }
    }
}
