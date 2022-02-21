using Microsoft.EntityFrameworkCore;
using MiPrimerAppMVC.Data.Interfaces;
using MiPrimerAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimerAppMVC.Data.Repository
{
    public class ProductoRepository : IProductoRepository
    {

        private readonly ProductosContext _context;
        public ProductoRepository(ProductosContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Producto>> GetAll()
        {
            
            IEnumerable<Producto> list = await _context.Productos.ToListAsync();

            return list;

        }

        public async Task<Producto> GetById(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            return producto;
        }

        public async Task<int> Create(Producto producto)
        {
            producto.FechaDeAlta = DateTime.Now;
            //var newProducto = _context.Add(producto);
            await _context.Productos.AddAsync(producto);
            return await _context.SaveChangesAsync();
             

        }
        public async Task<int> Update(Producto producto)
        {
            producto.FechaDeAlta = DateTime.Now;
            _context.Productos.Update(producto);
            return await _context.SaveChangesAsync();

        }

        public async Task<int> Delete(int id)
        {
            var producto = _context.Productos.Find(id);
             _context.Productos.Remove(producto);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteById(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
             _context.Productos.Remove(producto);
            if(await _context.SaveChangesAsync()>=0)
            {
                return true;
            }
            return false;
        }
    }
}
