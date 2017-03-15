using FluentNHibernate.Mapping;
using IngolStadtNatur.Entities.NH.Common;
using IngolStadtNatur.Entities.NH.Objects;
using System;
using System.Collections.Generic;

namespace IngolStadtNatur.Entities.NH.Observations
{
    public abstract class Observation : BaseEntity
    {
        public virtual string Comment { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual string Coordinates { get; set; }
        public virtual DateTime MeasurementDate { get; set; }
        public virtual Node Node { get; set; }
        public virtual ICollection<Shot> Shots { get; set; }
        public virtual Status Status { get; set; }

        public Observation()
        {
            Shots = new List<Shot>();
        }
    }

    public enum Status
    {
        Open = 0,
        Accepted = 1,
        Rejected = 2
    }

    public class ObservationMap : ClassMap<Observation>
    {
        public ObservationMap()
        {
            Table("Observations");

            Id(m => m.Id);

            Map(m => m.Comment);
            Map(m => m.CreationDate);
            Map(m => m.Coordinates);
            Map(m => m.MeasurementDate);
            References(m => m.Node)
                .Column("NodeRef")
                .Cascade.All();
            HasMany(m => m.Shots)
                .Inverse()
                .Cascade.All();
            Map(m => m.Status);
        }
    }
}
