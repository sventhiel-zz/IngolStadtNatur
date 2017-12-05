using FluentNHibernate.Mapping;
using IngolStadtNatur.Entities.NH.Common;
using IngolStadtNatur.Entities.NH.Observations;
using System.Collections.Generic;
using IngolStadtNatur.Entities.NH.Media;

namespace IngolStadtNatur.Entities.NH.Objects
{
    public abstract class Node : BaseEntity
    {
        public virtual ICollection<Category> Ancestors
        {
            get
            {
                var ancestors = new List<Category>();

                if (Parent == null) return ancestors;

                ancestors.Add(Parent);
                ancestors.AddRange(Parent.Ancestors);
                return ancestors;
            }
        }

        public virtual string CommonName { get; set; }
        public virtual string Description { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual bool IsPreviewed { get; set; }
        public virtual bool IsValid { get; set; }
        public virtual ICollection<Observation> Observations { get; set; }
        public virtual Category Parent { get; set; }
        public virtual string Reference { get; set; }
        public virtual string ScientificName { get; set; }
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
            HasManyToMany(m => m.Images)
                .Table("Nodes_Images")
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