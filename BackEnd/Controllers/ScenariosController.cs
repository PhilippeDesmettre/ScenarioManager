using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScenariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScenariosController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<Scenario>> PostScenario(Scenario scenario)
        {
            scenario.DateCreation = DateTime.UtcNow;
            scenario.UtilisateurId = 1;

            _context.Scenarios.Add(scenario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetScenario), new { id = scenario.Id }, scenario);
        }



        // GET: api/scenarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scenario>>> GetScenarios()
        {
            var scenarios = await _context.Scenarios
                .Include(s => s.Utilisateur) // Optionnel : inclut l'utilisateur
                .ToListAsync();

            return Ok(scenarios);
        }

        // GET: api/scenarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scenario>> GetScenario(int id)
        {
            var scenario = await _context.Scenarios
                .Include(s => s.Utilisateur)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (scenario == null)
                return NotFound();

            return Ok(scenario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScenario(int id)
        {
            var scenario = await _context.Scenarios.FindAsync(id);
            if (scenario == null)
            {
                return NotFound();
            }

            _context.Scenarios.Remove(scenario);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
