using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleProject.Models
{
    public class CriteriaSearch
    {
        public CriteriaSearch()
        {          
            StatusList = from status in Enum.GetValues(typeof(Status))
                                                       .Cast<Status>()
                                select new SelectListItem
                                {
                                    Text = status.ToString(),
                                    Value = ((int)status).ToString()
                                };
            
        }

        public string Name { get; set; }
        public string Number { get; set; }
        public string Customer { get; set; }
        public Status Status { get; set; }
        public IEnumerable<SelectListItem> StatusList { get; set; }
    }
}