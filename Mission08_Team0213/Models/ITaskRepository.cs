namespace Mission08_Team0213.Models
{
    public interface ITaskRepository
    {
        List<TaskTemplate> Tasks { get; }
        List<Category> Categories { get; }
        public void AddTask(TaskTemplate task);

        public void EditTask(TaskTemplate task);

        public void DeleteTask(TaskTemplate task);

	}
}
