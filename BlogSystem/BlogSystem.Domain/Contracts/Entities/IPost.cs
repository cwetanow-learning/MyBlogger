using BlogSystem.Domain.Models;
using BlogSystem.Domain.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Domain.Contracts.Entities
{
    public interface IPost : IDeletable
    {
        int PostId { get; set; }

        string Title { get; set; }

        string Subtitle { get; set; }

        string Text { get; set; }

        DateTime Date { get; set; }

        ICollection<Comment> Comments { get; }

        int Rating { get; set; }

        ApplicationUser Author { get; set; }
    }
}
