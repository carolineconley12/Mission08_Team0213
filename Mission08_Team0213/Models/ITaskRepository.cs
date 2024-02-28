namespace Mission08_Team0213.Models
{
    public interface ITaskRepository
    {
        List<TaskTemplate> Tasks { get; }
        public void AddTask(TaskTemplate task);
    }
}
