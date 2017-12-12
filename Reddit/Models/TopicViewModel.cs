using System;
namespace Reddit.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CreateTopicViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }
    }

    public class AnswerViewModel
    {
        [Required]
        [Display(Name = "Comment")]
        public string Comment { get; set; }
    }

    public class EditViewModel
    {
        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }
    }
}