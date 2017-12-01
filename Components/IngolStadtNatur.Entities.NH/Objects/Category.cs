using FluentNHibernate.Mapping;
using System.Collections.Generic;

namespace IngolStadtNatur.Entities.NH.Objects
{
    public class Category : Node
    {
        public virtual ICollection<Node> Children { get; set; }
        public virtual string Preview { get; set; }
        public virtual string UncertaintyHeader { get; set; }
        public virtual string UncertaintyText { get; set; }
    }

    public class CategoryMap : SubclassMap<Category>
    {
        public CategoryMap()
        {
            Table("Categories");

            HasMany(m => m.Children)
                .Inverse()
                .Cascade.All();
            Map(m => m.Preview);
            Map(m => m.UncertaintyHeader);
            Map(m => m.UncertaintyText);
        }
    }
}