namespace IngolStadtNatur.Entities.NH.Common
{
    public abstract class BaseEntity
    {
        public virtual long Id { get; set; }
        public virtual int Version { get; set; }
    }
}
