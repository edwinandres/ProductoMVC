using MiPrimerAppMVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiPrimerAppMVC.Data.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAll();

        //GetById
        Task<Producto> GetById(int id);

        //Update
        Task<int> Update(Producto producto);

        //Delete
        Task<bool> DeleteById(int id);

        //Create
        Task<int> Create(Producto producto);
    }


}
