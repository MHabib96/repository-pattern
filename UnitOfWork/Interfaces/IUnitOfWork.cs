using System;
using RepositoryPattern.Repositories.Interfaces;

namespace RepositoryPattern.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDeveloperRepository Developers { get; }
        IProjectRepository Projects { get; }
        int SaveChanges();
    }
}