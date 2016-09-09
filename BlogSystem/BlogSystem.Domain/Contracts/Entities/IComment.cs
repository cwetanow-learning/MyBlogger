﻿using BlogSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Domain.Contracts.Entities
{
    public interface IComment : IDeletable
    {
        int CommentId { get; set; }

        DateTime Date { get; set; }

        ApplicationUser Author { get; set; }

        string CommentText { get; set; }

        Post Post { get; set; }
    }
}
