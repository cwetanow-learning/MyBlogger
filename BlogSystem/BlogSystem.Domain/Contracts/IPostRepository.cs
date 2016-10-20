using BlogSystem.Domain.Contracts.Entities;
using BlogSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Domain.Contracts
{
    public interface IPostRepository
    {
        IEnumerable<IPost> Posts { get; }

        void SavePost(Post post, string authorId);

        IPost DeletePost(int postId);

        int ChangeRating(int postId, int value);

        IEnumerable<IPost> GetUserPosts(string userId);

        IPost GetPostById(int postId);

        IOrderedEnumerable<IPost> GetTopPosts();

        IOrderedEnumerable<IPost> GetLatestPosts();
    }
}
