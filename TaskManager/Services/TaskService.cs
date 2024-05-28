using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskService
    {
        private readonly List<TaskItem> _tasks = new List<TaskItem>
        {
            new TaskItem { Id = 1, Name = "Test Task 1", IsComplete = false },
            new TaskItem { Id = 2, Name = "Test Task 2", IsComplete = true }
        };

        public IEnumerable<TaskItem> GetAll() => _tasks;

        public TaskItem GetById(int id) => _tasks.FirstOrDefault(t => t.Id == id);

        public void Add(TaskItem task) => _tasks.Add(task);

        public void Update(TaskItem task)
        {
            var index = _tasks.FindIndex(t => t.Id == task.Id);
            if (index != -1)
            {
                _tasks[index] = task;
            }
        }

        public void Delete(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }
    }
}
