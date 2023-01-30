using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Producto_InsumoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Producto_InsumoId { get; set; }
        public int ProductoId { get; set; }
        public int InsumoId { get; set; }
        [ForeignKey("InsumoId")]
        public virtual InsumosModel? Insumo { get; set; }

    }
    
}
