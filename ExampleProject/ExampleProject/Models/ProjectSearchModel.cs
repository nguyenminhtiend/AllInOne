using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ExampleProject.Models
{
    public class ProjectSearchModel
    {
        public List<Project> Projects { get; set; }
        public Paging Page { get; set; }
    }
}