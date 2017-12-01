using IngolStadtNatur.Entities.NH.Observations;
using IngolStadtNatur.Persistence.NH;
using IngolStadtNatur.Services.Api.Observations;
using System.Linq;

namespace IngolStadtNatur.Services.NH.Observations
{
    public class ObservationManager : IObservationManager
    {
        public ObservationManager()
        {
            ObservationRepository = new Repository<Observation>();
        }

        public Repository<Observation> ObservationRepository { get; set; }
        public IQueryable<Observation> Observations => ObservationRepository.Query();

        public void Create(Observation observation)
        {
            ObservationRepository.Add(observation);
        }

        public void Delete(Observation observation)
        {
            ObservationRepository.Remove(observation);
        }

        public Observation FindById(long id)
        {
            return ObservationRepository.Get(id);
        }

        public void Update(Observation observation)
        {
            ObservationRepository.Update(observation);
        }
    }
}