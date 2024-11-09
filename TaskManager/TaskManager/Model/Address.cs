using System.ComponentModel.DataAnnotations;

namespace TaskManager.Model
{
    public class Address

    {
        [Key]
        public int Id { get; set; }

        public string Addressline1 { get; set; }


        public string? Addressline2 { get; set; }

        public string? city { get; set; }
        [Required]
        public  int? userid { get; set; }

        public User? user { get; set; }

    }
}
