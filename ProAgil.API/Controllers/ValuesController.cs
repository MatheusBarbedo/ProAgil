using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.API.Data;
using ProAgil.API.Model;

namespace ProAgil.API.Controllers
{
    [Route("site/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;

        }

        // GET site/values
        [HttpGet]
        public async Task<IActionResult> Get(){ 
            try{
                var results = await _context.Eventos.ToListAsync();
                return Ok(results);
            }
            catch (System.Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados falhou");
            } 
        }
        
        // GET site/values/5
        [HttpGet("{id}")]
        
        public async Task<IActionResult> Get(int id){
            try{
                var results = await _context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);
                return Ok(results);
            }
            catch (System.Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de dados falhou");
            } 
        }

        // POST site/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT site/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE site/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
