using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace APIFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Producto_InsumoController:ControllerBase
    {
        Producto_InsumoLogic producto_Insumo = new Producto_InsumoLogic();

        [HttpGet]
        public async Task<IActionResult> get()
        {
            List<Producto_InsumoModel> listaResultados = new List<Producto_InsumoModel>();
            listaResultados = await producto_Insumo.ListarTodo();
            return Ok(listaResultados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getId(int id)
        {
            Producto_InsumoModel resultado = new Producto_InsumoModel();
            resultado = await producto_Insumo.ObtenerPorId(id);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> post(Producto_InsumoModel request)
        {
            Producto_InsumoModel response = await producto_Insumo.CrearRegistro(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> put([FromBody] Producto_InsumoModel request)
        {
            Producto_InsumoModel response = await producto_Insumo.ActualizarRegistro(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var response = await producto_Insumo.EliminarRegistro(id);
            return Ok(response);
        }

    }
}
