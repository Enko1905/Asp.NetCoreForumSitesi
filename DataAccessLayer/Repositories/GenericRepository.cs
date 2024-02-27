﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var c = new RepositoryContext();
            c.Remove(t);
            c.SaveChanges();
        }

        public List<T> GetAll()
        {
            using var c = new RepositoryContext();
            return c.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            using var c = new RepositoryContext();
            return c.Set<T>().Find(id);
        }

        public void Insert(T t)
        {
            using var c = new RepositoryContext(); 
            c.Add(t);
            c.SaveChanges();
        }

        public void Update(T t)
        {
            using var c = new RepositoryContext();
            c.Update(t);
            c.SaveChanges();
        }
    }
}
