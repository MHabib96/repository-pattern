using RepositoryPattern.Database;
using RepositoryPattern.Models;
using RepositoryPattern.Repositories.Abstracts;
using RepositoryPattern.Repositories.Interfaces;

namespace RepositoryPattern.Repositories
{
    public class DeveloperRepository : Repository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(PlaygroundContext dbContext) : base(dbContext)
        {
            
        }
    }
}