using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Genre Name is required")]
        public string Name { get; set; }
    }
}
