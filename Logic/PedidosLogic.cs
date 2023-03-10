using Logic.Interface;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class PedidosLogic:ICRUDLogica<PedidosModel>
    {
        PedidosRepository repo = new PedidosRepository();

        public async Task<PedidosModel> ActualizarRegistro(PedidosModel input)
        {
            input = await repo.ActualizarRegistro(input);
            return input;
        }

        public async Task<PedidosModel> CrearRegistro(PedidosModel input)
        {
            input = await repo.CrearRegistro(input);
            return input;
        }

        public async Task<PedidosModel> EliminarRegistro(int id)
        {
            var xd = await repo.EliminarRegistro(id);
            return xd;
        }

        public async Task<List<PedidosModel>> ListarTodo()
        {
            List<PedidosModel> lista = await repo.ListarTodo();
            return lista;
        }

        public async Task<PedidosModel> ObtenerPorId(int id)
        {
            PedidosModel resultado = await repo.ObtenerPorId(id);
            return resultado;
        }
        public async Task<Pedido_ProductoModel> AddProductoToPedido(Pedido_ProductoModel input)
        {
            await repo.AddProductoToPedido(input);
            return input;
        }
    }
}
