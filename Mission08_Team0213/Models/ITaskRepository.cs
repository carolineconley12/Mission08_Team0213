namespace Mission08_Team0213.Models
{
    public interface ITaskRepository
    {
        IQueryable<TaskTemplate> Tasks { get; }
        IQueryable<Category> Categories { get; }
        public void AddTask(TaskTemplate task);

        public void EditTask(TaskTemplate task);

        public void DeleteTask(TaskTemplate task);

	}
}
