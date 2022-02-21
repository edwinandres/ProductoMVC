using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiPrimerAppMVC.Data;
using MiPrimerAppMVC.Data.Interfaces;
using MiPrimerAppMVC.Data.Repository;
using MiPrimerAppMVC.Models;

namespace MiPrimeraAppMVC.Controllers
{
    public class ProductoController : Controller
    {

        private readonly ProductosContext _context;
        private readonly DbSet<Producto> _productos;
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IProductoRepository productoRepository){
            _productoRepository = productoRepository;
        }

        //public List<Producto> productos;
        //Linea de codigo en vscode para probar en visual studioP

        public async Task<IActionResult> Index()
        {
            //var productos = GetData();
            //var productos = await _context.Productos.ToListAsync();
            var productos = await _productoRepository.GetAll();
            return View(productos);
        }

         public IActionResult Inicio()
        {
            return View();
        }

        //Get: localhost:5001/Producto/Create
        public IActionResult Create()
        {
            return View();
        }


        //Get: localhost:5001/Producto/Create
        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {

            if(ModelState.IsValid)
            {
                //Guardar en base de datos
                //producto.FechaDeAlta = DateTime.Now;
                //_context.Add(producto);
                //await _context.SaveChangesAsync();

                var result = await _productoRepository.Create(producto);
                if (result < 0)
                {
                    ViewBag.ErrorMessage="Error al guardar los datos";
                    return View(producto);
                }
                   

               return RedirectToAction(nameof(Index));
            }
           
            return View(producto);
        }

        //Get: localhost:5001/Producto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            var producto = await _productoRepository.GetById(id);        
            if(producto == null)
            {
                return NotFound();
            }   
            return View(producto);
        }

        //Post: localhost:5001/Producto/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if(id != producto.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                //producto.FechaDeAlta = DateTime.Now;
                //_context.Update(producto);
                //await _context.SaveChangesAsync();
                var result = await _productoRepository.Update(producto);
                if(result <0)
                {
                    ViewBag.ErrorMessage="Error al actualizar los datos";
                    return View(producto);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        //Get: localhost:5001/Producto/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            var producto = await _context.Productos.FindAsync(id);        
            if(producto == null)
            {
                return NotFound();
            }   
            return View(producto);
        }

        //Get: localhost:5001/Producto/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            //var producto = await _context.Productos.FindAsync(id);
            var producto = await _productoRepository.GetById(id);
            if(producto == null)
            {
                return NotFound();
            }   
           return View(producto);
        }


        //Post: localhost:5001/Producto/Delete/5
        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            //if(id != producto.Id)
            //{
            //    return NotFound();
            //}
            //if(ModelState.IsValid)
            //{
            //    _context.Remove(producto);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(producto);
            var result = await _productoRepository.DeleteById(id);
            if(result)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.ErrorMessage="Error al borrar el producto";
                return View();
            }
           

        }
        public List<Producto> GetData()
        {
            List<Producto> productos = new List<Producto>();
            productos.Add(new Producto{Id=1, Nombre="Cafe", Descripcion="Cafe en grano", Precio=1000, Activo=true, FechaDeAlta=DateTime.Now.AddDays(-1)});
            productos.Add(new Producto{Id=2, Nombre="Cafe colombiano", Descripcion="Cafe en grano de colombia", Precio=2000, Activo=true, FechaDeAlta=DateTime.Now.AddDays(-1)});            
            productos.Add(new Producto{Id=3, Nombre="Cafe en grano grueso", Descripcion="Cafe en grano grueso", Precio=3000, Activo=true, FechaDeAlta=DateTime.Now.AddDays(-1)});            
            productos.Add(new Producto{Id=4, Nombre="Cafe en grano fino", Descripcion="Cafe en grano fino", Precio=4000, Activo=true, FechaDeAlta=DateTime.Now.AddDays(-1)});           
            productos.Add(new Producto{Id=5, Nombre="Cafe gourmet", Descripcion="Cafe en grano gourmet", Precio=5000, Activo=true, FechaDeAlta=DateTime.Now.AddDays(-1)});
            
            return productos;
        }
    }
}