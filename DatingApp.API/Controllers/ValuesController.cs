using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{

    // http://localhost:5000/api/values || https://localhost:5001/api/values
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        // Get api/values/5
        [AllowAnonymous]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetValue(int Id)
        {
            
            var value = await  _context.Values.SingleOrDefaultAsync(x => x.Id == Id);
            var value2 =  await _context.Values.Where(x => x.Id == Id).ToListAsync();

            return Ok(value2);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {

        } 

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

    }
}