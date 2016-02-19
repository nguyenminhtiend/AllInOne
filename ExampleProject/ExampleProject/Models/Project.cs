using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleProject.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [RequiredIf("Name", Comparison.IsNotEqualTo, true)]
        public string Name2 { get; set; }
        [Remote("CheckExist", "Project", ErrorMessage = "Project Number have already existed!")]
        [Required]
        public int Number { get; set; }
        [Required]
        [NotEqualTo("Name")]
        public string Customer { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [DateGreaterThan("StartDate", "End date must be greater than the start date of the project")]
        public DateTime EndDate { get; set; }
        [BooleanRequired(ErrorMessage = "You must accept the terms and conditions.")]
        [Display(Name = "I accept the terms and conditions")]
        public bool TermsAndConditionsAccepted { get; set; }

    }
}