using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private static List<string> Tasks = new List<string>
        {
            "Aller à la salle",
            "Lire un livre",
            "Acheter du café"
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Tasks);
        }

        [HttpPost]
        public IActionResult AddTask([FromBody] string task)
        {
            if (string.IsNullOrWhiteSpace(task))
                return BadRequest("La tâche est vide.");

            Tasks.Add(task);
            return Ok(new { message = "Tâche ajoutée", value = task });
        }
    }
}
