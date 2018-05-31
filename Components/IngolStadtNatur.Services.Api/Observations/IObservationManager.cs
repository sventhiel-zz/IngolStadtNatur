using IngolStadtNatur.Entities.NH.Observations;
using System.Linq;

namespace IngolStadtNatur.Services.Api.Observations
{
    public interface IObservationManager
    {
        IQueryable<Observation> Observations { get; }
    }
}