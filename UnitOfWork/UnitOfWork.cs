using RepositoryPattern.Database;
using RepositoryPattern.Repositories;
using RepositoryPattern.Repositories.Interfaces;
using RepositoryPattern.UnitOfWork.Interfaces;

namespace RepositoryPattern.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlaygroundContext _playgroundContext;
        
        public UnitOfWork(PlaygroundContext playgroundContext)
        {
            _playgroundContext = playgroundContext;
            Developers = new DeveloperRepository(_playgroundContext);
            Projects = new ProjectRepository(_playgroundContext);
        }
        
        public IDeveloperRepository Developers { get; }
        public IProjectRepository Projects { get; }

        public int SaveChanges() => _playgroundContext.SaveChanges();
        
        public void Dispose() => _playgroundContext.Dispose();
    }
}