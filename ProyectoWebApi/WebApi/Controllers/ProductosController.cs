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
    public class ProductosController : ApiController
    {
        // GET api/<controller>
        public List<Productos> Get()
        {
            return ProductosData.Listar();
        }

        // GET api/<controller>/5
        //public Productos Gets(int id)
        //{
        //    return ProductosData.ObtenerProductos(id);

        //}

        // GET api/<controller>/5
        public List <Productos> Get(int id)
        {
            return ProductosData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody]Productos oCliente)
        {
            return ProductosData.Registrar(oCliente);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Productos oCliente)
        {
            return ProductosData.Modificar(oCliente);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return ProductosData.Eliminar(id);
        }
    }
}