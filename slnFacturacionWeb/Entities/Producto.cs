using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace slnFacturacionWeb.Entities
{
    public class Producto
    {
        [Key]
        public int CodigoProducto { get; set; }

        public int Valor { get; set; }

        public string Nombre { get; set; }
    }
}
