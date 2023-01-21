using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    [Table("Pedido_Producto")]
    public class Pedido_ProductoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Pedido_ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int TotalProducto { get; set; }
        [ForeignKey("PedidoId")]
        public int PedidoId { get; set; }
        [ForeignKey("ProductoId")]
        public int ProductoId { get; set; }
        [JsonIgnore]
        public virtual ProductosModel? Productos { get; set; }
        public virtual PedidosModel? Pedidos { get; set; }
    }
}
