namespace Mission08_Team0213.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskContext _context;

        public EFTaskRepository(TaskContext temp)
        {
            _context = temp;
        }

        public IQueryable<Category> Categories => _context.Categories;

        public IQueryable<TaskTemplate> Tasks => _context.Tasks;

        public void AddTask(TaskTemplate task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }

        public void EditTask (TaskTemplate task) 
        { 
            _context.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask (TaskTemplate task) 
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

	}

}
