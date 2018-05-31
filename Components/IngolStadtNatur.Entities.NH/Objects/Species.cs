using FluentNHibernate.Mapping;

namespace IngolStadtNatur.Entities.NH.Objects
{
    public class Species : Node
    {
        public Species()
        {
            IsSearchable = true;
            IsThreatened = false;
        }

        public virtual bool IsSearchable { get; set; }
        public virtual bool IsThreatened { get; set; }
    }

    public class SpeciesMap : SubclassMap<Species>
    {
        public SpeciesMap()
        {
            Table("Species");

            Map(m => m.IsSearchable);
            Map(m => m.IsThreatened);
        }
    }
}