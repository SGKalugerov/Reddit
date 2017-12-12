using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Reddit.Models
{
    public class Comment
    {
        public Comment()
        {
            Date = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}