using BlogSystem.Domain.Models;
using System;
using System.Collections.Generic;

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
