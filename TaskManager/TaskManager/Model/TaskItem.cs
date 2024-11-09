using System.ComponentModel.DataAnnotations;

namespace TaskManager.Model
{
    public class TaskItem
    {
        [Key]
        public int id {  get; set; }
        [Required]
        public string? title { get; set; }

        public string ?description { get; set; }
        public DateTime Duedate { get; set; }
        [Required]
        public string Priority {  get; set; }

        public int? assigneeId {  get; set; }
        public User? assignee { get; set; }

    }

}
