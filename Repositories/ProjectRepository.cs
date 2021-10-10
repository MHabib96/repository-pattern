using RepositoryPattern.Database;
using RepositoryPattern.Models;
using RepositoryPattern.Repositories.Abstracts;
using RepositoryPattern.Repositories.Interfaces;

namespace RepositoryPattern.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        protected ProjectRepository(PlaygroundContext dbContext) : base(dbContext)
        {
            
        }
    }
}