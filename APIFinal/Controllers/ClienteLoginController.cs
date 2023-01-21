using Contraseña;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Context;

namespace APIFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteLoginController : ControllerBase
    {
        _dbContext db = new _dbContext();
        [HttpPost]
        public async Task<ActionResult> Login(string Usuario, string Contrasena)
        {
            var query = from c in db.clientes
                        where c.Usuario == Usuario
                        select c;
            List<ClienteModel> clientes = await query.ToListAsync();
            if (clientes.Count > 0)
            {
                string encryptedPassword = clientes[0].Contrasena;
                string userPassword = Encriptacion.GetSHA256(Contrasena);
                if (encryptedPassword == userPassword)
                {
                    return Ok(clientes[0]);
                }
            }
            return NotFound();
        }
    }
}
