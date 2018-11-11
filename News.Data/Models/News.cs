using System;
using System.ComponentModel.DataAnnotations;

namespace News.Data.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        [StringLength(600)]
        public string Title { get; set; }

        [StringLength(6000)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
