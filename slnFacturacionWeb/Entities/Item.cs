using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace slnFacturacionWeb.Entities
{
    public class Item
    {
        [Key]
        public int CodigoItem { get; set; }
        public int CodigoProducto { get; set; }

        public int Cantidad { get; set; }
        public int ValorTotal { get; set; }


    }
}
