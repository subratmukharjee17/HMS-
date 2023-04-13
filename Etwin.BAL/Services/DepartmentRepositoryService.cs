using Etwin.DAL.DataRepository;
using Etwin.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Etwin.BAL.Services
{
    public class DepartmentRepositoryService
    {
        public readonly IGenericRepository<Departments> _repository;
        public DepartmentRepositoryService(IGenericRepository<Departments> repository)

        {
            _repository = repository;
        }

        public IEnumerable<Departments> GetAll()
        {
            var model = _repository.GetAll();
            return model;
        }

        public Departments GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Delete(Departments departmentId)
        {
            _repository.Delete(departmentId);
            _repository.Save();
        }

    }
}
