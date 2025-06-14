﻿using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Scenario>> PostScenario(Scenario scenario)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
            if (userIdClaim == null)
                return Unauthorized();

            var userId = int.Parse(userIdClaim.Value);
            var user = await _context.Utilisateurs.FindAsync(userId);
            if (user == null)
                return NotFound("Utilisateur introuvable.");

            scenario.DateCreation = DateTime.UtcNow;
            scenario.UtilisateurId = user.Id;
            scenario.Auteur = user.Email; // ou user.Nom si tu ajoutes un pseudo

            _context.Scenarios.Add(scenario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetScenario), new { id = scenario.Id }, scenario);
        }



        [Authorize]
        [HttpGet]
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scenario>>> GetScenarios()
        {
            var userId = int.Parse(User.FindFirst("id")!.Value);

            return await _context.Scenarios
                .Where(s => s.EstPublic || s.UtilisateurId == userId)
                .ToListAsync();
        }


        [Authorize]
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

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScenario(int id, Scenario scenario)
        {
            if (id != scenario.Id)
            {
                return BadRequest();
            }

            // Maj date de modificaiton.
            scenario.DateModification = DateTime.UtcNow;

            _context.Entry(scenario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Scenarios.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [Authorize]
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
