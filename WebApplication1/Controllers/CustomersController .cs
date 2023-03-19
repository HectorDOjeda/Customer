using Customer.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Customer.Models;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomerController(CustomerContext context)
        {
            _context = context;

            if (_context.Customer.Count() == 0)
            {
                try
                {
                    _context.Customer.Add(new Models.Customer { RazonSocial = "Juan Perez", TipoDocumento = "DNI", NroDocumento = "12345678", Direccion = "Calle Falsa 123" });
                    _context.SaveChanges();
                }catch(DbUpdateException ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        //get all customers
        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Customer>>> GetCustomer()
        {
            return await _context.Customer.ToListAsync();
        }

        //get customer by id
        //api/Customer/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        //create customer
        // POST: api/Customer
        [HttpPost]
        public async Task<ActionResult<Models.Customer>> PostCustomer(Models.Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        //update customer
        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Models.Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        //delete customer by id
        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
