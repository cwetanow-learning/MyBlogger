using BlogSystem.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Domain.Models.Abstract
{
    public class DeletableEntity : IDeletable
    {
        public bool IsDeleted
        {
            get; set;
        }
    }
}
