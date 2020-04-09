using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using slnFacturacionWeb.Contexts;
using slnFacturacionWeb.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace slnFacturacionWeb.Controllers
{
    
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly AppDbContext _context;

        public ProductoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [Route("producto")]
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return _context.Producto.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Route("producto/id")]
        public Producto Get(int id)
        {
            var producto = _context.Producto.FirstOrDefault(p => p.CodigoProducto == id);
            return producto;
        }

        // POST api/<controller>


        [HttpPost]
        [Route("producto/save-product")]
        public ActionResult Post([FromBody]Producto producto)
        {
            try
            {
                _context.Producto.Add(producto);
                _context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {

                return BadRequest();
            }

        }

        // PUT api/<controller>/5
        [HttpPost]
        [Route("producto/update-product")]
        public ActionResult Put( [FromBody]Producto producto)
        {
            if (producto.CodigoProducto != 0)
            {
                _context.Entry(producto).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else {
                return BadRequest();
            }
        }

        // DELETE api/<controller>/5

        [HttpPost]
        [Route("producto/delete-product")]
        public ActionResult Delete([FromBody]Producto productoD)
        {
            var producto = _context.Producto.FirstOrDefault(p => p.CodigoProducto == productoD.CodigoProducto);

            if (producto != null)
            {
                _context.Producto.Remove(producto);
                _context.SaveChanges();
                return Ok();
            }
            else {

                return BadRequest();

            }
        }
    }
}
