using IngolStadtNatur.Entities.NH.Media;
using System.Linq;

namespace IngolStadtNatur.Services.Api.Objects
{
    public interface IShotManager
    {
        IQueryable<Shot> Shots { get; }
    }
}