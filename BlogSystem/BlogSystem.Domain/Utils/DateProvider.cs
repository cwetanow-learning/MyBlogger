using System;
using BlogSystem.Domain.Contracts;

namespace BlogSystem.Domain.Utils
{
    public class DateProvider : IDateProvider
    {
        public DateTime BannedUserTime()
        {
            var timeLeft = this.GetCurrentDate().AddYears(200);

            return timeLeft;
        }

        public DateTime GetCurrentDate()
        {
            var currentDate = DateTime.Now;

            return currentDate;
        }


    }
}
