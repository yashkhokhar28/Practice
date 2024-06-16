using System;
using System.ComponentModel.DataAnnotations;

namespace Practice.Areas.LOC_Country.Models
{
    public class LOC_CountryModel
    {
        public int CountryID { get; set; }

        [Required(ErrorMessage = "Country name is required")]
        [StringLength(100, ErrorMessage = "Country name cannot be longer than 100 characters")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Country code is required")]
        [StringLength(10, ErrorMessage = "Country code cannot be longer than 10 characters")]
        public string CountryCode { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }

    public class LOC_CountryDropDownModel
    {
        public int CountryID { get; set; }

        public string CountryName { get; set; }
    }
}