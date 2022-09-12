using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace Desafio_EF.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public T Insert(T item);
        public ICollection<T> GetAll();
        public T GetById(int id);
        public void Put(T item);
        public void Patch(JsonPatchDocument patchItem, T item);
        public void Delete(T item);
    }
}
