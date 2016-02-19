using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleProject.Models
{
    public class ParamRequest
    {
        public int ItemPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int ColumnSort { get; set; }
        public string DirectionSort { get; set; }
        public string SearchString { get; set; }
    }
}