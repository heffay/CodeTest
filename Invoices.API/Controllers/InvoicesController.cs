using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Invoices.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceRepository _repo;

        public InvoicesController(IInvoiceRepository repo){
            _repo = repo;

            if(!_repo.GetAll().Any()){
                var fakes = GenFakeInvoices();
                foreach(var invoice in fakes){
                    _repo.Create(invoice);
                }
            }
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IList<Invoice>> Get()
        {
            var allInvoices = _repo.GetAll("Lines");
            return Ok(allInvoices);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var invoice = await _repo.GetById(id,"Lines");
            return Ok(invoice);
        }

        // Create
        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Invoice invoice)
        {
            if(invoice == null)
                return BadRequest();

            await _repo.Create(invoice);
            return CreatedAtRoute("GetInvoice", new { Controller = "Invoice", id = invoice.Id }, invoice);
        }

        // Update
        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Invoice invoice)
        {
            if(invoice == null)
                return BadRequest();

            var test = _repo.GetById(id);
            if(test == null)
                return NotFound();

            await _repo.Update(invoice);
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var test = _repo.GetById(id);
            if(test == null)
                return NotFound();

            await _repo.Delete(id);
            return NoContent();
        }

        private IList<Invoice> GenFakeInvoices(){
                return new List<Invoice>(){
                    new Invoice(){
                        Id = "0aj9fh34pf3h",
                        CustomerName = "Jamie Jordan",
                        Lines = new List<InvoiceLine>() {
                            new InvoiceLine() {
                                Id = "IL-001",
                                ProductCode = "WMNZR",
                                Price = 199,
                                Quantity = 1
                            },
                            new InvoiceLine() {
                                Id = "IL-002",
                                ProductCode = "TCLNR",
                                Price = 9.99,
                                Quantity = 1
                            }
                        }
                    },
                    new Invoice(){
                        Id = "09823n9i",
                        CustomerName = "Kris Kross",
                        Lines = new List<InvoiceLine>() {
                            new InvoiceLine() {
                                Id = "IL-009",
                                ProductCode = "CTHNGR",
                                Price = 2.99,
                                Quantity = 10
                            },
                            new InvoiceLine() {
                                Id = "IL-010",
                                ProductCode = "MTHBLZ",
                                Price = 9.99,
                                Quantity = 5
                            }
                        }
                    },
                };
        }
    }
}
