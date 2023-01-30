using Logic.Interface;
using Models;
using Repository;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Producto_InsumoLogic: ICRUDLogica<Producto_InsumoModel>
    {
        Producto_InsumoRepository repo = new Producto_InsumoRepository();

        public async Task<Producto_InsumoModel> ActualizarRegistro(Producto_InsumoModel input)
        {
            input = await repo.ActualizarRegistro(input);
            return input;
        }

        public async Task<Producto_InsumoModel> CrearRegistro(Producto_InsumoModel  input)
        {
            input = await repo.CrearRegistro(input);
            return input;
        }

        public async Task<Producto_InsumoModel> EliminarRegistro(int id)
        {
            var xd = await repo.EliminarRegistro(id);
            return xd;
        }

        public async Task<List<Producto_InsumoModel>> ListarTodo()
        {
            List<Producto_InsumoModel> lista = await repo.ListarTodo();
            return lista;
        }

        public async Task<Producto_InsumoModel> ObtenerPorId(int id)
        {
            Producto_InsumoModel resultado = await repo.ObtenerPorId(id);
            return resultado;
        }
    }
}
