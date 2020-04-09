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
    public class ItemController : Controller
    {
        private readonly AppDbContext _context;

        public ItemController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _context.Item.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Item Get(int id)
        {
            var item = _context.Item.FirstOrDefault(p => p.CodigoItem == id);
            return item;
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Item item)
        {
            try
            {
                _context.Item.Add(item);
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
        public ActionResult Put(int id, [FromBody]Item item)
        {
            if (item.CodigoItem == id)
            {
                _context.Entry(item).State = EntityState.Modified;
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
            var item = _context.Item.FirstOrDefault(p => p.CodigoItem == id);

            if (item != null)
            {
                _context.Item.Remove(item);
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
