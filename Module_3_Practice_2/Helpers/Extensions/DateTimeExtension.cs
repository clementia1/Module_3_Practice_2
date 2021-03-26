using System;
using System.Collections.Generic;
using System.Text;

namespace Module_3_Practice_2.Helpers.Extensions
{
    public static class DateTimeExtension
    {
        public static bool IsCurrentMonth(this DateTime dateTime)
        {
            if (DateTime.UtcNow.Month == dateTime.Month)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
