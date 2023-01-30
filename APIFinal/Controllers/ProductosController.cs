using APIFinal.Controllers.ResponseData;
using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repository;

namespace APIFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ILogger<ProductosController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        ProductosLogic productosLogic = new ProductosLogic();
        ProductosRepository repository = new ProductosRepository();
        public ProductosController(ILogger<ProductosController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet]
        public async Task<IActionResult> get()
        {
            List<ProductosModel> listaResultados = new List<ProductosModel>();
            listaResultados = await productosLogic.ListarTodo();
            return Ok(listaResultados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getId(int id)
        {
            ProductosModel resultado = new ProductosModel();
            resultado = await productosLogic.ObtenerPorId(id);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> post(ProductosModel request)
        {
            ProductosModel response = await productosLogic.CrearRegistro(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> put([FromBody] ProductosModel request)
        {
            ProductosModel response = await productosLogic.ActualizarRegistro(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var response = await productosLogic.EliminarRegistro(id);
            return Ok(response);
        }
        #region image
        [HttpPut]
        [Produces("application/json")]
        [Route("{productoId}/agregar-imagen")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<object>> AddImageAsync([FromRoute] int productoId, [FromForm] FileImage body)
        {
            //copiar la imagen y generar el path
            try
            {
                string path = await CopyImageAsync(body.imageFile, productoId);
                bool isOk = await repository.AddImageAsync(productoId, path);
                return isOk ? Ok(new { imageUrl = path }) : NotFound();
            }
            catch (Exception ex)
            {
                var err = new ErrorResponse
                {
                    status = 20001,
                    message = ex.Message,
                };
                return Ok(err);
            }
        }
        private async Task<string> CopyImageAsync(IFormFile image, int id)
        {
            List<string> aceptedMimeTypes = new List<string> {
                  "image/jpg","image.jpeg", "image/png"};
            string mimetype = image.ContentType;
            if (aceptedMimeTypes.Where(m => m == mimetype).Count() <= 0)
            {
                throw new Exception("Tipo de archivo invalido");
            }
            long size = image.Length;
            if (size > 2048000)//2MB
            {
                throw new Exception("No archivos mayores a 2 MB");
            }
            else if (size > 0)
            {
                string ext = image.FileName.Split('.').Last();
                string wwwroot = _webHostEnvironment.WebRootPath;
                string nameImage = $"producto-{id}.{ext}";
                string file = Path.Combine(wwwroot, "uploads", "productos", nameImage);
                //System.IO.File.Delete(file);
                using (var stream = System.IO.File.Create(file))
                {
                    await image.CopyToAsync(stream);
                }
                return $"/uploads/productos/{nameImage}";
            }
            throw new Exception("archivo invalido");
        }
        #endregion
    }
    public class FileImage
    {
        public IFormFile imageFile { get; set; }
    }
}
