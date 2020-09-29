using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BurgersDB.Models
{
    // Model class for Burger Table
    public class Burger
    {
        // Unique key data annotation
        [Key]
        public int BurgerId { get; set; }
        // burger company name
        [Display(Name = "Burger Name")]
        [Required(ErrorMessage ="You did not entered burger company")]
        public string Name { get; set; }
        // burger company address
        [Display(Name = "Company Address")]
        [Required(ErrorMessage = "You did not entered burger company address")]
        public string Address { get; set; }
        // burger company telephone
        [Required(ErrorMessage = "You did not entered burger company telephone number")]
        [Display(Name = "Company Telephone")]
        public string Telephone { get; set; }

    }
}
