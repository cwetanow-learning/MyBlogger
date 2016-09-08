using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Domain.Contracts.Entities
{
    public interface IPost
    {
        int PostId { get; set; }

        string Title { get; set; }

        string Subtitle { get; set; }

        string Text { get; set; }

        DateTime Date { get; set; }

        IEnumerable<IComment> Comments { get; }

        int Rating { get; set; }

        IApplicationUser Author { get; set; }
    }
}
