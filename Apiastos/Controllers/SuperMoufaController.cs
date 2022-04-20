using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apiastos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperMoufaController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperMoufaController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Supermoufa>>> Get()
        {
            return Ok(await _context.Supermoufas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Supermoufa>>> Get(int id)
        {
            var moufa = await _context.Supermoufas.FindAsync(id);
            if (moufa == null)
            {
                return BadRequest("mlkies psaxneis!! papara");
            }
            return Ok(moufa);
        }

        [HttpPost]
        public async Task<ActionResult<List<Supermoufa>>> AddHero(Supermoufa moufa)
        {
            _context.Supermoufas.Add(moufa);
            await _context.SaveChangesAsync();

            return Ok(await _context.Supermoufas.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Supermoufa>>> UpdateHero(Supermoufa moufa)
        {
            var hero = await _context.Supermoufas.FindAsync(moufa.Id);
            if (hero == null)
                return BadRequest("not found. Exeis valei lathos id");

            hero.Name = moufa.Name;
            hero.FirstName = moufa.FirstName;
            hero.LastName = moufa.LastName;
            hero.Place = moufa.Place;

            await _context.SaveChangesAsync();
            return Ok(await _context.Supermoufas.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Supermoufa>>> DeleteHero(int id)
        {
            var moufa = await _context.Supermoufas.FindAsync(id);
            if (moufa == null)
                return BadRequest("mlkies psaxneis!! papara");

            _context.Supermoufas.Remove(moufa);
            await _context.SaveChangesAsync();

            return Ok(await _context.Supermoufas.ToListAsync());
        }
    }
}