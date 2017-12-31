using System;
using System.Collections.Generic;
using Transportation.Models;

namespace Transportation.Interfaces
{
    public interface ICalendarService
    {
        IEnumerable<TimeTableViewModel> GetTable();
        TimeTableViewModel AddRecord(TimeTableUpdateModel table);
        TimeTableViewModel UpdateRecord(int id, TimeTableUpdateModel record);
        TimeTableViewModel ChangeDate(int id, DayOfWeek day, TimeSpan time);
        void DeleteRecord(int id);
    }
}
