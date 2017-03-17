using IngolStadtNatur.Entities.NH.Objects;
using IngolStadtNatur.Persistence.NH;
using IngolStadtNatur.Services.Api.Objects;
using System.Linq;

namespace IngolStadtNatur.Services.NH.Objects
{
    public class ShotManager : IShotManager
    {
        public Repository<Shot> ShotRepository { get; set; }

        public ShotManager()
        {
            ShotRepository = new Repository<Shot>();
        }

        public IQueryable<Shot> Shots => ShotRepository.Query();

        public void Create(Shot entity)
        {
            ShotRepository.Add(entity);
        }

        public void Delete(Shot entity)
        {
            ShotRepository.Remove(entity);
        }

        public Shot GetShot(long id)
        {
            return ShotRepository.Get(id);
        }

        public void Update(Shot entity)
        {
            ShotRepository.Update(entity);
        }
    }
}
