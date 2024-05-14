using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraversalApiProject.DAL.Context;
using TraversalApiProject.DAL.Entities;

namespace TraversalApiProject.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult VisitorList()
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.ToList();
                return Ok(values); // 200 lü kod döndürür 
            }
        }

        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                context.Add(visitor);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpGet("{id}")]
        public IActionResult VisitorGet(int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(values);
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult VisitorDelete(int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    context.Remove(values);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }

        [HttpPut]
        public IActionResult VisitorUpdate(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Find<Visitor>(visitor.VisitorID); // burası araştırılmalı
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    values.Name = visitor.Name;
                    values.Surname = visitor.Surname;
                    values.City = visitor.City;
                    values.Country = visitor.Country;
                    context.Update(values);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}
