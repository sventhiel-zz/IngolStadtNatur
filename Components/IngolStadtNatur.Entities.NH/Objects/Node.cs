using FluentNHibernate.Mapping;
using IngolStadtNatur.Entities.NH.Common;
using IngolStadtNatur.Entities.NH.Observations;
using System.Collections.Generic;

namespace IngolStadtNatur.Entities.NH.Objects
{
    public abstract class Node : BaseEntity
    {
        public virtual string Description { get; set; }
        public virtual bool IsPreviewed { get; set; }
        public virtual bool IsValid { get; set; }
        public virtual ICollection<Observation> Observations { get; set; }
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

            Id(m => m.Id);
            Version(m => m.Version);

            Map(m => m.Description).Length(1024);
            Map(m => m.IsPreviewed);
            Map(m => m.IsValid);
            HasMany(m => m.Observations)
                .Inverse()
                .Cascade.All();
            References(m => m.Parent)
                  .Column("ParentRef")
                  .Cascade.All();
            Map(m => m.Reference);
            Map(m => m.ScientificName);
            Map(m => m.CommonName);
        }
    }
}
