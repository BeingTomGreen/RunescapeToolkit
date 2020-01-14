using Core.Models;
using System;

namespace Core.Helpers
{
    class ActivityHelper
    {
        public static bool ValidateActivityName(string activityName)
        {
            if (Enum.IsDefined(typeof(PlayerActivity), activityName))
                return true;

            return false;
        }

    }
}
