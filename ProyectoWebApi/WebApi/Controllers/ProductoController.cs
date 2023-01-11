using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ProductoController : ApiController
    {
        
        // GET api/<controller>/5
        public Producto Get(int id)
        {
            return ProductoData.Obtener(id);

        }

    }
}