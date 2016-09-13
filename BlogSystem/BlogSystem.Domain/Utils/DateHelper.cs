using System;

namespace BlogSystem.Domain.Utils
{
    public static class DateHelper
    {
        public static DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }

        public static DateTime BanUser()
        {
            return GetCurrentTime().AddYears(GlobalConstants.YearsBan);
        }
    }
}
