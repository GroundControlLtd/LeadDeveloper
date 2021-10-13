using System;
using Shared;

namespace Data
{
    public class GarageRepository : IGarageRepository
    {
        public DateTime BookMot(Car car)
        {
            var now = DateTime.Now;
            var date = new DateTime(now.Year, now.Month, now.Day, 11, 15, 0).AddDays(3);
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                date = date.AddDays(2); 
            }

            return date; 
        }
    }
}
