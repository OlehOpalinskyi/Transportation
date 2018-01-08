using System;
using System.Collections.Generic;
using System.Web.Http;
using Transportation.Interfaces;
using Transportation.Models;

namespace Transportation.Controllers
{
    [RoutePrefix("timetable")]
    public class TimeTableController : ApiController
    {
        private readonly ICalendarService _service;

        public TimeTableController(ICalendarService service)
        {
            _service = service;
        }

        public IEnumerable<TimeTableViewModel> GetTable()
        {
            return _service.GetTable();
        }

        [Route("")]
        [HttpPost]
        public TimeTableViewModel AddRecord(TimeTableUpdateModel table)
        {
            return _service.AddRecord(table);
        }

        [Route("{id}")]
        [HttpPut]
        public TimeTableViewModel UpdateRecord(int id, TimeTableUpdateModel record)
        {
            return _service.UpdateRecord(id, record);
        }

        [Route("{id}")]
        [HttpPatch]
        public TimeTableViewModel ChangeDate(int id, DayOfWeek day, TimeSpan time)
        {
            return _service.ChangeDate(id, day, time);
        }

        [Route("{id}")]
        [HttpDelete]
        public void DeleteRecord(int id)
        {
            _service.DeleteRecord(id);
        }
    }
}
