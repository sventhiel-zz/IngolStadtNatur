using IngolStadtNatur.Entities.NH.Objects;
using System.Linq;

namespace IngolStadtNatur.Services.Api.Objects
{
    public interface INodeManager
    {
        IQueryable<Node> Nodes { get; }
    }
}