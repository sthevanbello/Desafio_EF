﻿using Desafio_EF.Contexts;
using Desafio_EF.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Desafio_EF.Repositories
{
    /// <summary>
    /// Repositório usado como base para os métodos Post, Get, GetById, Update e Delete
    /// </summary>
    /// <typeparam name="T">Classe a ser utilizada no repositório</typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly DesafioContext _context;

        public BaseRepository(DesafioContext desafioContext)
        {
            _context = desafioContext;
            _dbSet = _context.Set<T>();
        }

        public void Put(T item)
        {
            _dbSet.Update(item);
            _context.SaveChanges();
        }

        public void Patch(JsonPatchDocument patchItem, T item)
        {
            patchItem.ApplyTo(item);
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Delete(T item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public T Insert(T item)
        {
            var retorno = _dbSet.Add(item);
            _context.SaveChanges();
            return retorno.Entity;
        }

        public ICollection<T> GetAll()
        {
            var query = _dbSet.AsQueryable();
            return query.ToList();
        }
    }
}
