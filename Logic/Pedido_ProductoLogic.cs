﻿using Logic.Interface;
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
    public class Pedido_ProductoLogic: ICRUDLogica<Pedido_ProductoModel>
    {
        Pedido_ProductoRepository repo = new Pedido_ProductoRepository();

        public async Task<Pedido_ProductoModel> ActualizarRegistro(Pedido_ProductoModel input)
        {
            input = await repo.ActualizarRegistro(input);
            return input;
        }

        public async Task<Pedido_ProductoModel> CrearRegistro(Pedido_ProductoModel input)
        {
            input = await repo.CrearRegistro(input);
            return input;
        }

        public async Task<Pedido_ProductoModel> EliminarRegistro(int id)
        {
            var xd = await repo.EliminarRegistro(id);
            return xd;
        }

        public async Task<List<Pedido_ProductoModel>> ListarTodo()
        {
            List<Pedido_ProductoModel> lista = await repo.ListarTodo();
            return lista;
        }

        public async Task<Pedido_ProductoModel> ObtenerPorId(int id)
        {
            Pedido_ProductoModel resultado = await repo.ObtenerPorId(id);
            return resultado;
        }
    }
}
