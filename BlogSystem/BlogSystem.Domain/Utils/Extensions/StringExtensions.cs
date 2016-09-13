namespace BlogSystem.Domain.Utils.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string text)
        {
            var result = string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text);

            return result;
        }
    }
}
