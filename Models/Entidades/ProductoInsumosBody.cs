using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entidades
{
     public class ProductoInsumosBody
    {
        public ProductosModel producto { get; set; }
        public List<InsumosModel> insumos { get; set; }
    }
}
