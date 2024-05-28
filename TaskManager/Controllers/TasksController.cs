using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TasksController()
        {
            _taskService = new TaskService();
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskItem>> GetTasks()
        {
            return Ok(_taskService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<TaskItem> GetTask(int id)
        {
            var task = _taskService.GetById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public ActionResult<TaskItem> PostTask(TaskItem task)
        {
            _taskService.Add(task);
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult PutTask(int id, TaskItem task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }
            _taskService.Update(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            _taskService.Delete(id);
            return NoContent();
        }
    }
}
