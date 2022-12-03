using Demo_API_NET5.Datas;
using Demo_API_NET5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_API_NET5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CustomerController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var Customers = await _context.Customer.Select(a => new { a.Id, a.Name, a.DoB, a.Address, a.IsDeleted, a.Gender }).ToListAsync();
            return Ok(Customers);
        }

        [HttpPost]
        public async Task<IActionResult> create(CustomerDTO customer)
        {
            try
            {
                var newCustomer = new Customer
                {
                    Address = customer.Address,
                    DoB = customer.DoB,
                    Gender = customer.Gender,
                    Name = customer.Name,
                    Phone = customer.Phone,
                    IsDeleted = false,
                };
                await _context.AddAsync(newCustomer);
                _context.SaveChanges();
                return Ok(new
                {
                    StatusCode= 200,
                    CreatedAt= DateTime.Now,
                    Data = newCustomer
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
