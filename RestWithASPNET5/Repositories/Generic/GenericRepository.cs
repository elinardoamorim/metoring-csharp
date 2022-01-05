using Microsoft.EntityFrameworkCore;
using RestWithASPNET5.Models;
using RestWithASPNET5.Models.Base;
using RestWithASPNET5.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Repositories.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private SqlServerContext _context;
        private DbSet<T> dataset;

        public GenericRepository(SqlServerContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }
        public T Create(T t)
        {
            try
            {
                dataset.Add(t);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return t;
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            if(result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindByID(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T t)
        {
            if (Exists(t.Id))
            {
                var result = dataset.SingleOrDefault(p => p.Id.Equals(t.Id));
                if(result != null)
                {
                    try
                    {
                        _context.Entry(result).CurrentValues.SetValues(t);
                        _context.SaveChanges();
                    } 
                    catch (Exception)
                    {
                        throw;
                    }
                    return result;
                }
            }
            return null;
        }

        public bool Exists(long id)
        {
            return dataset.Any(p => p.Id.Equals(id));
        }
    }
}
