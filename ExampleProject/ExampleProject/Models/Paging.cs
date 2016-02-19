using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExampleProject.Models
{
    public class Paging
    {
        public int Total { get; set; }
        public int CurrentPage { get; set; }
        public bool IsFirst
        {
            get { return CurrentPage > 0; }
        }
        public bool IsLast
        {
            get { return CurrentPage < Total - 1; }
        }
        public int PreviousPage
        {
            get { return CurrentPage - 1; }
        }
        public int NextPage
        {
            get { return CurrentPage + 1; }
        }
    }
}