namespace BlogSystem.Domain.Utils
{
    public static class MathHelper
    {
        public static bool IsPositive(int value)
        {
            return value > 0;
        }

        public static bool IsNegative(int value)
        {
            return value < 0;
        }
    }
}
