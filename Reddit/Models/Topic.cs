namespace Reddit.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Topic
    {
        public Topic()
        {
            Date = DateTime.Now;
            Comments = new List<Comment>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }  
        public DateTime Date { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}