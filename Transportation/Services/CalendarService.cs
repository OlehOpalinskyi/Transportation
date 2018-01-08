using System;
using System.Collections.Generic;
using System.Linq;
using Transportation.Data;
using Transportation.Data.Models;
using Transportation.Interfaces;
using Transportation.Models;
using static AutoMapper.Mapper;

namespace Transportation.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly DataContext _db;

        public CalendarService(DataContext db)
        {
            _db = db;
        }

        public IEnumerable<TimeTableViewModel> GetTable()
        {
            var dataTable = _db.TimeTable;

            return Map<IEnumerable<TimeTableViewModel>>(dataTable);
        }

        public TimeTableViewModel AddRecord(TimeTableUpdateModel table)
        {
            var dataTable = CreateRecord(table);
            _db.TimeTable.Add(dataTable);
            _db.SaveChanges();

            return Map<TimeTableViewModel>(dataTable);
        }

        public TimeTableViewModel UpdateRecord(int id, TimeTableUpdateModel record)
        {
            var newRecord = CreateRecord(record);
            newRecord.Id = id;
            var currentRecord = _db.TimeTable.Single(t => t.Id == id);
            _db.Entry(currentRecord).CurrentValues.SetValues(newRecord);
            _db.SaveChanges();

            return Map<TimeTableViewModel>(newRecord);
        }

        public TimeTableViewModel ChangeDate(int id, DayOfWeek day, TimeSpan time)
        {
            var record = _db.TimeTable.Single(t => t.Id == id);
            record.Day = day;
            record.Time = time;
            _db.SaveChanges();

            return Map<TimeTableViewModel>(record);
        }

        public void DeleteRecord(int id)
        {
            var record = _db.TimeTable.Single(t => t.Id == id);
            _db.TimeTable.Remove(record);
            _db.SaveChanges();
        }

        private TimeTableDataModel CreateRecord(TimeTableUpdateModel record)
        {
            var dataRecord = Map<TimeTableDataModel>(record);
            var bus = _db.Buses.Single(b => b.Id == record.BusId);
            var route = _db.Routes.Single(r => r.Id == record.RouteId);

            dataRecord.Route = route;
            dataRecord.Bus = bus;

            return dataRecord;
        }
    }
}