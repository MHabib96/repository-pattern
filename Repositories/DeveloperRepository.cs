using RepositoryPattern.Database;
using RepositoryPattern.Models;
using RepositoryPattern.Repositories.Abstracts;
using RepositoryPattern.Repositories.Interfaces;

namespace RepositoryPattern.Repositories
{
    public class DeveloperRepository : Repository<Developer>, IDeveloperRepository
    {
        protected DeveloperRepository(PlaygroundContext dbContext) : base(dbContext)
        {
            
        }
    }
}