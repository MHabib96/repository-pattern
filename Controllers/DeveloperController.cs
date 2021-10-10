using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models;
using RepositoryPattern.UnitOfWork.Interfaces;

namespace RepositoryPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DeveloperController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeveloperController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public Developer Get(Guid id)
        {
            return _unitOfWork.Developers.GetById(id);
        }

        [HttpGet]
        public IEnumerable<Developer> GetAll()
        {
            return _unitOfWork.Developers.GetAll();
        }
    }
}