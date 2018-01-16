using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
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

        [ResponseType(typeof(IEnumerable<TimeTableViewModel>))]
        public IHttpActionResult GetTable()
        {
            return Ok(_service.GetTable());
        }

        [Route("")]
        [HttpPost]
        [ResponseType(typeof(TimeTableViewModel))]
        public IHttpActionResult AddRecord(TimeTableUpdateModel table)
        {
            return Ok(_service.AddRecord(table));
        }

        [Route("{id}")]
        [HttpPut]
        [ResponseType(typeof(TimeTableViewModel))]
        public IHttpActionResult UpdateRecord(int id, TimeTableUpdateModel record)
        {
            return Ok(_service.UpdateRecord(id, record));
        }

        [Route("{id}")]
        [HttpPatch]
        [ResponseType(typeof(TimeTableViewModel))]
        public IHttpActionResult ChangeDate(int id, DayOfWeek day, TimeSpan time)
        {
            return Ok(_service.ChangeDate(id, day, time));
        }

        [Route("{id}")]
        [HttpDelete]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteRecord(int id)
        {
            _service.DeleteRecord(id);
            return Ok();
        }
    }
}
