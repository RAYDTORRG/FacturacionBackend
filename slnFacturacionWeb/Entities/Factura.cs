using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace slnFacturacionWeb.Entities
{
    public class Factura
    {
        [Key]
        public int CodigoFactura { get; set; }

        public string Cliente { get; set; }

        public int CodigoItem { get; set; }

        public int ValorTotal { get; set; }
    }
}
