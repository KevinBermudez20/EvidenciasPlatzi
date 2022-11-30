using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Models;

namespace ApiRest.Services
{
    public class CategoriaService : ICategoriaService
    {
        TareasContext _context;
        public CategoriaService(TareasContext context)
        {
            _context = context;
        }
        public IEnumerable<Categoria> Get()
        {
            return _context.Categorias;
        }
        public async Task Save(Categoria categoria)
        {
            _context.Add(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Categoria categoria)
        {
            var categoriaActual = _context.Categorias.Find(id);
            if (categoriaActual != null)
            {
                categoriaActual.Nombre = categoria.Nombre;
                categoriaActual.Descripcion = categoria.Descripcion;
                categoriaActual.Peso = categoria.Peso;
                await _context.SaveChangesAsync();
            }

        }

        public async Task Delete(Guid id)
        {
            var categoriaActual = _context.Categorias.Find(id);
            if (categoriaActual != null)
            {
                _context.Remove(categoriaActual);
                await _context.SaveChangesAsync();
            }

        }


    }

    public interface ICategoriaService
    {
        IEnumerable<Categoria> Get();
        Task Delete(Guid id);
        Task Update(Guid id, Categoria categoria);
        Task Save(Categoria categoria);
    }
}