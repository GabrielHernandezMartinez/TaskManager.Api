using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Data;
using TaskManager.Api.Models;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context) => _context = context;

        // GET /api/tasks 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetAll([FromQuery] TaskPriority? priority)
        {
            var query = _context.Tasks.AsQueryable();
            if (priority.HasValue)
                query = query.Where(t => t.Priority == priority.Value);

            return await query.ToListAsync();
        }

        // POST /api/tasks
        [HttpPost]
        public async Task<ActionResult<TaskItem>> Create(TaskItem task)
        {
            // 1. Validación de Fecha
            if (task.DueDate < DateTime.Now)
            {
                return BadRequest("La fecha de vencimiento no puede ser anterior a la fecha actual.");
            }

            // 2. LÓGICA INTELIGENTE: Analizador de Prioridad
            // Agregue ?. y ?? "" para manejar nulos de forma segura
            string descripcion = task.Description?.ToLower() ?? "";

            if (descripcion.Contains("urgente") ||
                descripcion.Contains("inmediato") ||
                descripcion.Contains("importante") ||
                descripcion.Contains("prioridad alta"))
            {
                task.Priority = TaskPriority.High;
            }

            // 3. Validación de Título
            if (string.IsNullOrWhiteSpace(task.Title))
            {
                return BadRequest("El título de la tarea es obligatorio.");
            }

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = task.Id }, task);
        }
        // PUT /api/tasks/{id}/complete
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> MarkComplete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            task.IsCompleted = true;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /api/tasks/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}