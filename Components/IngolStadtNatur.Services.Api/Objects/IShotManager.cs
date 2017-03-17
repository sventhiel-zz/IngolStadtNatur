using IngolStadtNatur.Entities.NH.Objects;
using System.Linq;

namespace IngolStadtNatur.Services.Api.Objects
{
    public interface IShotManager
    {
        IQueryable<Shot> Shots { get; }
    }
}
