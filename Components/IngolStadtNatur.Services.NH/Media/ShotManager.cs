using IngolStadtNatur.Entities.NH.Media;
using IngolStadtNatur.Persistence.NH;
using IngolStadtNatur.Services.Api.Objects;
using System.Linq;

namespace IngolStadtNatur.Services.NH.Media
{
    public class ShotManager : IShotManager
    {
        public ShotManager()
        {
            ShotRepository = new Repository<Shot>();
        }

        public Repository<Shot> ShotRepository { get; set; }
        public IQueryable<Shot> Shots => ShotRepository.Query();

        public void Create(Shot shot)
        {
            ShotRepository.Add(shot);
        }

        public void Delete(Shot shot)
        {
            ShotRepository.Remove(shot);
        }

        public Shot FindById(long id)
        {
            return ShotRepository.Get(id);
        }

        public void Update(Shot shot)
        {
            ShotRepository.Update(shot);
        }
    }
}