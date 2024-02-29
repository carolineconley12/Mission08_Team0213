using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0213.Models
{
    public class TaskTemplate
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateOnly? DueDate { get; set; }
        public int Quadrant { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? CategoryName { get; set; }
        public bool? Completed { get; set; }

    }
}
