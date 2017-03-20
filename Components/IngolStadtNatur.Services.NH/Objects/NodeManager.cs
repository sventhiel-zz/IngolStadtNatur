﻿using IngolStadtNatur.Entities.NH.Objects;
using IngolStadtNatur.Persistence.NH;
using IngolStadtNatur.Services.Api.Objects;
using System.Linq;

namespace IngolStadtNatur.Services.NH.Objects
{
    public class NodeManager : INodeManager
    {
        public Repository<Category> CategoryRepository { get; set; }
        public Repository<Node> NodeRepository { get; set; }
        public Repository<Species> SpeciesRepository { get; set; }

        public NodeManager()
        {
            NodeRepository = new Repository<Node>();
            SpeciesRepository = new Repository<Species>();
        }

        public IQueryable<Category> Categories => CategoryRepository.Query();
        public IQueryable<Node> Nodes => NodeRepository.Query();
        public IQueryable<Species> Species => SpeciesRepository.Query();

        public void Create(Node node)
        {
            NodeRepository.Add(node);
        }

        public void Delete(Node node)
        {
            NodeRepository.Remove(node);
        }

        public Category GetCategory(long id)
        {
            return CategoryRepository.Get(id);
        }

        public Node GetNode(long id)
        {
            return NodeRepository.Get(id);
        }

        public Category GetRoot()
        {
            return Categories.FirstOrDefault(m => m.Parent == null);
        }

        public Species GetSpecies(long id)
        {
            return SpeciesRepository.Get(id);
        }

        public void Update(Node node)
        {
            NodeRepository.Update(node);
        }
    }
}
