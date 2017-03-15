using FluentNHibernate.Mapping;
using IngolStadtNatur.Entities.NH.Common;

namespace IngolStadtNatur.Entities.NH.Objects
{
    public abstract class Node : BaseEntity
    {
        public virtual string Description { get; set; }
        public virtual bool IsPreviewed { get; set; }
        public virtual bool IsValid { get; set; }
        public virtual Category Parent { get; set; }
        public virtual string Reference { get; set; }
        public virtual string ScientificName { get; set; }
        public virtual string CommonName { get; set; }
    }

    public class NodeMap : ClassMap<Node>
    {
        public NodeMap()
        {
            Table("Nodes");

            Map(m => m.Description).Length(1024);
            Id(m => m.Id);
            Map(m => m.IsPreviewed);
            Map(m => m.IsValid);
            References(m => m.Parent)
                  .Column("ParentRef")
                  .Cascade.All();
            Map(m => m.Reference);
            Map(m => m.ScientificName);
            Map(m => m.CommonName);
        }
    }
}
