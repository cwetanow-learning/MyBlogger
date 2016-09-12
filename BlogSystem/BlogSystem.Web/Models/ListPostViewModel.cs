using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.Web.Models
{
    public class ListPostViewModel
    {
        public bool ByDate { get; set; }

        public bool ByRating { get; set; }
    }
}