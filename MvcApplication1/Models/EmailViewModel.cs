using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class EmailViewModel
    {
        public bool IsBusiness { get; set; }
        public bool IsInvoice { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Receivers { get; set; }
    }
}