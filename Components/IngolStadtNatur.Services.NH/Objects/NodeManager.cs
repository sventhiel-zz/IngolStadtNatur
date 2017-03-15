using IngolStadtNatur.Entities.NH.Objects;
using IngolStadtNatur.Persistence.NH;
using IngolStadtNatur.Services.Api.Objects;
using System.Linq;

namespace IngolStadtNatur.Services.NH.Objects
{
    public class NodeManager : INodeManager
    {
        public Repository<Node> NodeRepository { get; set; }

        public NodeManager()
        {
            NodeRepository = new Repository<Node>();
        }

        public IQueryable<Node> Nodes => NodeRepository.Query();

        public void Create(Node entity)
        {
            NodeRepository.Add(entity);
        }

        public void Delete(Node entity)
        {
            NodeRepository.Remove(entity);
        }

        public void Update(Node entity)
        {
            NodeRepository.Update(entity);
        }
    }
}
