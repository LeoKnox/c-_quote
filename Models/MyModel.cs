using System;
using System.ComponentModel.DataAnnotations;

namespace quoting_dojo.Models
{
    public class MyModel
    {
        [Required]
        [Display(Name = "Your Name")]
        public string quoteName {get; set;}

        [Required]
        [Display(Name = "Your Quote")]
        public string quoteQuote {get; set;}

        public MyModel ()
        {
            
        }
       
    }
}