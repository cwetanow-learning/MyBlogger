using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Domain.Utils
{
    public static class GlobalConstants
    {
        public static int HomePageTopPostsCount = 5;
        public static int ListPostCount = 10;

        public static int IdOfEntityNotInDB = 0;

        public static int MinimumPostRating = 0;
        public static int DislikePostValue = -1;
        public static int LikePostValue = 1;

        public static string AdministratorRole = "Admin";
    }
}
