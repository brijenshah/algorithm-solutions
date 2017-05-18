using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class ToDoItemsController : ApiController
    {
        readonly ToDoItemContext _context = new ToDoItemContext();

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _context.ToDoItems.ToListAsync());
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string id)
        {
            var item = await _context.ToDoItems.FindAsync(id);

            if (item == null) return NotFound();

            return Ok(item);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(ToDoItem item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ToDoItemExist(item.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(ToDoItem item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.ToDoItems.Add(item);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (await ToDoItemExist(item.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("Default", new {id = item.Id}, item);
        }

        private async Task<bool> ToDoItemExist(string id)
        {
            return await _context.ToDoItems.CountAsync(item => item.Id == id) > 0;
        }
    }
}