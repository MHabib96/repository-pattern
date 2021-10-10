using RepositoryPattern.Models;

namespace RepositoryPattern.Repositories.Interfaces
{
    public interface IDeveloperRepository : IRepository<Developer>
    {
        //Add Repository behaviour exclusive to Developer.
    }
}