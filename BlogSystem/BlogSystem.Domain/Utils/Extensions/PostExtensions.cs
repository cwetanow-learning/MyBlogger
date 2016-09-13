using BlogSystem.Domain.Contracts.Entities;

namespace BlogSystem.Domain.Utils.Extensions
{
    public static class PostExtensions
    {
        public static bool PostContainsPattern(this IPost post, string pattern)
        {
            var titleContains = post.Title.Contains(pattern);
            var subtitleContains = post.Subtitle.Contains(pattern);
            var textContains = post.Text.Contains(pattern);

            var result = titleContains || subtitleContains || textContains;

            return result;
        }
    }
}
