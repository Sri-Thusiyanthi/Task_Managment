﻿using System.ComponentModel.DataAnnotations;

namespace TaskManager.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
    

        public Address? Address { get; set; }
       public ICollection<TaskItem>? Items { get; set; }          



    }
}
