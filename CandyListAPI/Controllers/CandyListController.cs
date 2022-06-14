using CandyStore.Data;
using CandyStore.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CandyListAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandyListController : ControllerBase
    {
        private readonly DataContext _context;

        public CandyListController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Candy>> Get()
            => await _context.Candy.ToListAsync();


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Candy), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await _context.Candy.FindAsync(id);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Candy candy)
        {
            await _context.Candy.AddAsync(candy);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = candy.CandyID }, candy);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Candy candy)
        {
            if (id != candy.CandyID) return BadRequest();

            _context.Entry(candy).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int CandyID)
        {
            var issueToDelete = await _context.Candy.FindAsync(CandyID);
            if (issueToDelete != null) return NotFound();


            _context.Candy.Remove(issueToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }




    }

}
