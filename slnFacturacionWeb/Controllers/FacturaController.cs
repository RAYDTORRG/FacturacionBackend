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
    [Route("api/[controller]")]
    public class FacturaController : Controller
    {
        private readonly AppDbContext _context;

        public FacturaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Factura> Get()
        {
            return _context.Factura.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Factura Get(int id)
        {
            var factura = _context.Factura.FirstOrDefault(p => p.CodigoFactura == id);
            return factura;
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Factura factura)
        {
            try
            {
                _context.Factura.Add(factura);
                _context.SaveChanges();
                return Ok();

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Factura factura)
        {
            if (factura.CodigoFactura == id)
            {
                _context.Entry(factura).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var factura = _context.Factura.FirstOrDefault(p => p.CodigoFactura == id);

            if (factura != null)
            {
                _context.Factura.Remove(factura);
                _context.SaveChanges();
                return Ok();
            }
            else
            {

                return BadRequest();

            }
        }
    }
}
