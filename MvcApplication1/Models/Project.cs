using System;
using System.ComponentModel;
using System.Web.Mvc;

namespace MvcApplication1.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Cusotmer { get; set; }
        public Status Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
    public class ProjectTest
    {
        //[AllowHtml]
        public string Name { get; set; }
        public string Cusotmer { get; set; }
    }

    public enum Status
    {
        [Description("Starting Starting")]
        Starting = 1,
        [Description("Pending Pending")]
        Pending = 2,
        [Description("Completed Completed")]
        Completed = 3
    }
    public class StringValue : System.Attribute
    {
        private string _value;

        public StringValue(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }

    }
}