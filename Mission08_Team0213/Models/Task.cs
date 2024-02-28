using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0213.Models
{
    public class Task
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateOnly? DueDate { get; set; }
        public int Quadrant { get; set; }
        public string? Category { get; set; }
        public bool? Completed { get; set; }

    }
}
