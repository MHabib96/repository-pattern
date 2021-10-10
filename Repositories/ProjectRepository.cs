using RepositoryPattern.Database;
using RepositoryPattern.Models;
using RepositoryPattern.Repositories.Abstracts;
using RepositoryPattern.Repositories.Interfaces;

namespace RepositoryPattern.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(PlaygroundContext dbContext) : base(dbContext)
        {
            
        }
    }
}