using IngolStadtNatur.Entities.NH.Observations;
using IngolStadtNatur.Persistence.NH;
using IngolStadtNatur.Services.Api.Observations;
using System.Linq;

namespace IngolStadtNatur.Services.NH.Observations
{
    public class ObservationManager : IObservationManager
    {
        public Repository<Observation> ObservationRepository { get; set; }

        public ObservationManager()
        {
            ObservationRepository = new Repository<Observation>();
        }

        public IQueryable<Observation> Observations => ObservationRepository.Query();

        public void Create(Observation entity)
        {
            ObservationRepository.Add(entity);
        }

        public void Delete(Observation entity)
        {
            ObservationRepository.Remove(entity);
        }

        public void Update(Observation entity)
        {
            ObservationRepository.Update(entity);
        }
    }
}
