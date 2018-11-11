using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace News.Common.News.BindingModels
{
    public class NewsListingViewModel
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
