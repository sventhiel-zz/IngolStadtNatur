using IngolStadtNatur.Entities.NH.Objects;
using System.Linq;
using IngolStadtNatur.Entities.NH.Media;

namespace IngolStadtNatur.Services.Api.Objects
{
    public interface IShotManager
    {
        IQueryable<Shot> Shots { get; }
    }
}
