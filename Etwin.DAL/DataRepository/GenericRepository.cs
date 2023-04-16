using EtwLogin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Etwin.DAL.DataRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ETWLoginContext _context;
        private DbSet<T> _entity = null;

        public GenericRepository(ETWLoginContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

       

        public IEnumerable<T> GetAll()
        {
            return _entity.ToList();
        }

        public T GetById(object id)
        {
            return _entity.Find(id);
        }

        public void Insert(T obj)
        {
            _entity.Add(obj);
        }

        public void Update(T obj)
        {
            _entity.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = _entity.Find(id);
            _entity.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }


    }

}
