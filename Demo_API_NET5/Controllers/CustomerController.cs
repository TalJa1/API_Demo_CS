using Demo_API_NET5.Datas;
using Demo_API_NET5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        [HttpGet("{customerId}")]
        public async Task<IActionResult> getById(int customerId)
        {
            try
            {
                var customer = await _context.Customer.SingleOrDefaultAsync(a => a.Id == customerId);
                if(customer == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode= 200,
                        Data= customer
                    });
                }
            }
            catch
            {
                return BadRequest();
            }
            
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

        [HttpPut("setDeleteCustomer/{customerId}")]
        public async Task<IActionResult> setDeleteCustomer(int customerId)
        {
            try
            {
                var customer = await _context.Customer.FirstOrDefaultAsync(a => a.Id == customerId);
                if(customer == null) { return NotFound();}
                else
                {
                    customer.IsDeleted = true;
                    _context.Customer.Update(customer);
                    _context.SaveChanges();
                    return Ok(new
                    {
                        StatusCode= 200,
                        CustomerIdDeleted= customerId
                    });
                }
            }
            catch 
            { 
            return BadRequest();
            }
        }

        //[HttpDelete("{customerID}")]
        //public async Task<IActionResult> deleteById(int CustomerId) 
        //{
        //    try
        //    {
        //        var customer = await _context.Customer.FirstOrDefaultAsync(a => a.Id == CustomerId);
        //        if (customer == null)
        //        {
        //            return NotFound();
        //        }
        //        _context.Customer.Remove(customer);
        //        await _context.SaveChangesAsync();
        //        return Ok();
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}


    }
}
