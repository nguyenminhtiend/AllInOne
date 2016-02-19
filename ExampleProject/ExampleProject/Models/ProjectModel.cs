using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ExampleProject.Models
{
    public class ProjectModel
    {
        public List<Project> ListProjects { get; set; }
        public Paging Page { get; set; }   
    }
}