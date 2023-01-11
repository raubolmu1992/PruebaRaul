using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string TipoProducto { get; set; }
        public string CodigoUnico { get; set; }
        public string NombreProducto { get; set; }
        public string Activo { get; set; }
        public string Cantidad { get; set; }
        public string Valor { get; set; }
    }
}