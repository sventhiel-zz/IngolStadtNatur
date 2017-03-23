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

        public void Create(Observation observation)
        {
            ObservationRepository.Add(observation);
        }

        public void Delete(Observation observation)
        {
            ObservationRepository.Remove(observation);
        }

        public Observation Get(long id)
        {
            return ObservationRepository.Get(id);
        }

        public void Update(Observation observation)
        {
            ObservationRepository.Update(observation);
        }
    }
}
