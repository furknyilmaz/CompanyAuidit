using CompanyAuidit.Contexts;
using CompanyAuidit.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CompanyAuidit.Services
{
    public abstract class BaseService <TEntity> where TEntity :  class, new()
    {
        private readonly CompanyAuiditContext _context;

        protected BaseService(CompanyAuiditContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(TEntity entity, int id)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public  List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
    }
}
