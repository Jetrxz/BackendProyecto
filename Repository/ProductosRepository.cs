using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductosRepository:ICRUD<ProductosModel>
    {
        _dbContext db = new _dbContext();

        public async Task<ProductosModel> ActualizarRegistro(ProductosModel input)
        {
            db.productos.Update(input);
            await db.SaveChangesAsync();
            return input;
        }

        public async Task<ProductosModel> CrearRegistro(ProductosModel input)
        {
            await db.productos.AddAsync(input);
            await db.SaveChangesAsync();
            return input;
        }

        public async Task<ProductosModel> EliminarRegistro(int id)
        {
            var xd = await db.productos.FindAsync(id);
            db.productos.Remove(xd);
            await db.SaveChangesAsync();
            return xd;
        }

        public async Task<List<ProductosModel>> ListarTodo()
        {
            List<ProductosModel> lista = await db.productos
                                         .Include(z => z.Categorias)
                                         .Include(z => z.Preparacion.PreparacionInsumo.Insumos.TipoUnidad)
                                         .ToListAsync();
            return lista;
        }

        public async Task<ProductosModel> ObtenerPorId(int id)
        {
            ProductosModel pedido = await db.productos.FindAsync(id);
            return pedido;
        }
        #region imagenes
        public async Task<bool> AddImageAsync(int id, string path)
        {
            ProductosModel? productos = await db.productos.FindAsync(id);
            if (productos == null)
            {
                throw new Exception("No existe el producto");
            }
            productos.ImageUrl = path;
            int res = await db.SaveChangesAsync();
            //operador ternario
            return (res > 0) ? true : false;
        }
        #endregion
    }
}
