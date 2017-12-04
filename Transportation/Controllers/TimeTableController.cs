using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Transportation.Data;
using Transportation.Data.Models;
using Transportation.Models;
using static AutoMapper.Mapper;

namespace Transportation.Controllers
{
    [RoutePrefix("timetable")]
    public class TimeTableController : ApiController
    {
        private readonly DataContext _db;

        public TimeTableController(DataContext db)
        {
            _db = db;
        }

        [Route("")]
        public IEnumerable<TimeTableViewModel> GetTable()
        {
            var dataTable = _db.TimeTable;

            return Map<IEnumerable<TimeTableViewModel>>(dataTable);
        }

        [Route("")]
        [HttpPost]
        public TimeTableViewModel AddRecord(TimeTableUpdateModel table)
        {
            var dataTable = CreateRecord(table);
            _db.TimeTable.Add(dataTable);
            _db.SaveChanges();

            return Map<TimeTableViewModel>(dataTable);
        }

        [Route("{id}")]
        [HttpPut]
        public TimeTableViewModel UpdateRecord(int id, TimeTableUpdateModel record)
        {
            var newRecord = CreateRecord(record);
            newRecord.Id = id;
            var currentRecord = _db.TimeTable.Single(t => t.Id == id);
            _db.Entry(currentRecord).CurrentValues.SetValues(newRecord);
            _db.SaveChanges();

            return Map<TimeTableViewModel>(newRecord);
        }

        [Route("{id}")]
        [HttpPatch]
        public TimeTableViewModel ChangeDate(int id, DayOfWeek day, TimeSpan time)
        {
            var record = _db.TimeTable.Single(t => t.Id == id);
            record.Day = day;
            record.Time = time;
            _db.SaveChanges();

            return Map<TimeTableViewModel>(record);
        }

        [Route("{id}")]
        [HttpDelete]
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
