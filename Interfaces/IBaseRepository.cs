using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace Desafio_EF.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public T Inserir(T item);
        public ICollection<T> ListarTodos();
        public T BuscarPorId(int id);
        public void Alterar(T item);
        public void AlterarParcialmente(JsonPatchDocument patchItem, T item);
        public void Excluir(T item);
    }
}
