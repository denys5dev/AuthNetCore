using System;
using Microsoft.AspNetCore.Http;

namespace AuthNetCore.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Applicaton-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
        }

        public static int CalculateAge(this DateTime theDateTiem)
        {
            var age = DateTime.Today.Year - theDateTiem.Year;
            if(theDateTiem.AddYears(age) > DateTime.Today)
            {
                age--;
            }

            return age;
        }
    }
}