using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Producto_InsumoRepository
    {
        _dbContext db = new _dbContext();

        public async Task<Producto_InsumoModel> ActualizarRegistro(Producto_InsumoModel input)
        {
            db.producto_Insumos.Update(input);
            await db.SaveChangesAsync();
            return input;
        }

        public async Task<Producto_InsumoModel> CrearRegistro(Producto_InsumoModel input)
        {
            await db.producto_Insumos.AddAsync(input);
            await db.SaveChangesAsync();
            return input;
        }

        public async Task<Producto_InsumoModel> EliminarRegistro(int id)
        {
            var xd = await db.producto_Insumos.FindAsync(id);
            db.producto_Insumos.Remove(xd);
            await db.SaveChangesAsync();
            return xd;
        }

        public async Task<List<Producto_InsumoModel>> ListarTodo()
        {
            List<Producto_InsumoModel> lista = await db.producto_Insumos
                                         .Include(z => z.Inumos)
                                         .ToListAsync();
            return lista;
        }

        public async Task<Producto_InsumoModel> ObtenerPorId(int id)
        {
            
            Producto_InsumoModel insumos = await db.producto_Insumos.FindAsync(id);
            return insumos;
        }

    }
}
