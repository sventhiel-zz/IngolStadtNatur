using IngolStadtNatur.Entities.NH.Objects;
using IngolStadtNatur.Persistence.NH;
using IngolStadtNatur.Services.Api.Objects;
using System.Linq;

namespace IngolStadtNatur.Services.NH.Objects
{
    public class NodeManager : INodeManager
    {
        public NodeManager()
        {
            CategoryRepository = new Repository<Category>();
            NodeRepository = new Repository<Node>();
            SpeciesRepository = new Repository<Species>();
        }

        public IQueryable<Category> Categories => CategoryRepository.Query();
        public Repository<Category> CategoryRepository { get; set; }
        public Repository<Node> NodeRepository { get; set; }
        public IQueryable<Node> Nodes => NodeRepository.Query();
        public IQueryable<Species> Species => SpeciesRepository.Query();
        public Repository<Species> SpeciesRepository { get; set; }

        public void Create(Node node)
        {
            NodeRepository.Add(node);
        }

        public void Delete(Node node)
        {
            NodeRepository.Remove(node);
        }

        public Node FindById(long id)
        {
            return NodeRepository.Get(id);
        }

        public Node FindByName(string name)
        {
            return Nodes.FirstOrDefault(m => m.CommonName.ToUpperInvariant() == name.ToUpperInvariant());
        }

        public Category FindRoot()
        {
            return Categories.FirstOrDefault(m => m.Parent == null);
        }

        public void Update(Node node)
        {
            NodeRepository.Update(node);
        }
    }
}