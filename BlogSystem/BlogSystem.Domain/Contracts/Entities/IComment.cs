using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Domain.Contracts.Entities
{
    public interface IComment
    {
        int CommentId { get; set; }

        DateTime Date { get; set; }

        IApplicationUser Author { get; set; }

        string CommentText { get; set; }

        int PostId { get; set; }
    }
}
