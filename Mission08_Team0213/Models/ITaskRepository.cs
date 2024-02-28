namespace Mission08_Team0213.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }
        public void AddTask(Task task);
    }
}
