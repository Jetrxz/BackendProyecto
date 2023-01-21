using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;

namespace Models
{
    [Table("Cliente")]
    public class ClienteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClienteId { get; set; }
        [MaxLength(100)]
        public string Nombres { get; set; }
        [MaxLength(100)]
        public string Apellidos { get; set; }
        public int Celular { get; set; }
        [MaxLength(100)]
        public string Usuario { get; set; }
        [MaxLength(100)]
        public string Contrasena { get; set; }
    }
}
                