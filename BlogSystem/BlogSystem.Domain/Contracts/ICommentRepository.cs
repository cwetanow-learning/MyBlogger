﻿using BlogSystem.Domain.Contracts.Entities;
using BlogSystem.Domain.Models;
using System.Collections.Generic;

namespace BlogSystem.Domain.Contracts
{
    public interface ICommentRepository
    {
        IEnumerable<IComment> Comments { get; }

        void WriteComment(Comment comment, int postId, string authorId);

        void DeleteComment(int commentId);

        IEnumerable<IComment> GetPostCommentsById(int postId);

        IEnumerable<IComment> GetCommentsFromIds(IEnumerable<int> commentIds);

        IEnumerable<IComment> GetUserComments(string userId);
    }
}
