using System;
using System.Collections.Generic;
using Transportation.Interfaces;
using Transportation.Models;

namespace Transportation.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly ICalendarService _service;

        public CalendarService(ICalendarService service)
        {
            _service = service;
        }

        public IEnumerable<TimeTableViewModel> GetTable()
        {
            return _service.GetTable();
        }

        public TimeTableViewModel AddRecord(TimeTableUpdateModel table)
        {
            return _service.AddRecord(table);
        }

        public TimeTableViewModel UpdateRecord(int id, TimeTableUpdateModel record)
        {
            return _service.UpdateRecord(id, record);
        }

        public TimeTableViewModel ChangeDate(int id, DayOfWeek day, TimeSpan time)
        {
            return _service.ChangeDate(id, day, time);
        }

        public void DeleteRecord(int id)
        {
            _service.DeleteRecord(id);
        }
    }
}