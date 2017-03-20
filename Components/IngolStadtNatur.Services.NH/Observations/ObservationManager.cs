using IngolStadtNatur.Entities.NH.Observations;
using IngolStadtNatur.Persistence.NH;
using IngolStadtNatur.Services.Api.Observations;
using System.Linq;

namespace IngolStadtNatur.Services.NH.Observations
{
    public class ObservationManager : IObservationManager
    {
        public Repository<CategoryObservation> CategoryObservationRepository { get; set; }
        public Repository<Observation> ObservationRepository { get; set; }
        public Repository<SpeciesObservation> SpeciesObservationRepository { get; set; }

        public ObservationManager()
        {
            CategoryObservationRepository = new Repository<CategoryObservation>();
            ObservationRepository = new Repository<Observation>();
            SpeciesObservationRepository = new Repository<SpeciesObservation>();
        }

        public IQueryable<CategoryObservation> CategoryObservations => CategoryObservationRepository.Query();
        public IQueryable<Observation> Observations => ObservationRepository.Query();
        public IQueryable<SpeciesObservation> SpeciesObservations => SpeciesObservationRepository.Query();

        public void Create(Observation observation)
        {
            ObservationRepository.Add(observation);
        }

        public void Delete(Observation observation)
        {
            ObservationRepository.Remove(observation);
        }

        public CategoryObservation GetCategoryObservation(long id)
        {
            return CategoryObservationRepository.Get(id);
        }

        public Observation GetObservation(long id)
        {
            return ObservationRepository.Get(id);
        }

        public SpeciesObservation GetSpeciesObservation(long id)
        {
            return SpeciesObservationRepository.Get(id);
        }

        public void Update(Observation observation)
        {
            ObservationRepository.Update(observation);
        }
    }
}
