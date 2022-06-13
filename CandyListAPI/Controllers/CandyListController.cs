using CandyStore.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace CandyListAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandyListController : ControllerBase
    {
        readonly IHttpContextAccessor _contextAccessor;

        public CandyListController(IHttpContextAccessor context) => _contextAccessor = context;

        [HttpGet]
        public async Task<IEnumerable<Candy>> Get()
            => await _contextAccessor.Candy.ToListAsync();


        [HttpGet("id")]
        [ProducesResponseType(typeof(Candy), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await _contextAccessor.Candy.FindAsync(id);
            return issue == null ? NotFound() : Ok(issue);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Candy candy)
        {
            await _contextAccessor.Candy.AddAsync(Candy);
            await _contextAccessor.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = candy.CandyID }, candy);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Candy candy)
        {
            if (id != candy.CandyID) return BadRequest();

            _contextAccessor.Entry(candy).State = EntityState.Modified;
            await _contextAccessor.SaveChangesAsyncy();

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var issueToDelete = await _contextAccessor.Candy.FindAsync(id);
            if (issueToDelete != null) return NotFound();

            _contextAccessor.Candy.Remove(issueToDelete);
            await _contextAccessor.SaveChangesAsync();

            return NoContent();
        }




    }

}
