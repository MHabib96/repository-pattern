using RepositoryPattern.Models;

namespace RepositoryPattern.Repositories.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        //Add Repository behaviour exclusive to Project.
    }
}