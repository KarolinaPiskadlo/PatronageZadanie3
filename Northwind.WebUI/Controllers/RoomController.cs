using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Rooms.Commands.CreateRoom;
using Northwind.Application.Rooms.Commands.DeleteRoom;
using Northwind.Application.Rooms.Commands.UpdateRoom;
using Northwind.Application.Rooms.Models;
using Northwind.Application.Rooms.Queries.GetRoomCalendar;
using Northwind.Application.Rooms.Queries.GetRoomDetails;
using Northwind.Application.Rooms.Queries.GetRooms;
using Northwind.Domain.Entities;

namespace Northwind.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : BaseController
    {
        // GET: api/Room
        [HttpGet]
        public async Task<ActionResult<RoomViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetRoomsQuery()));
        }

        // GET: api/Room/5/calendar
        [HttpGet("{id}/calendar")]
        public async Task<ActionResult<CalendarViewModel>> GetCalendar(int id)
        {
            return Ok(await Mediator.Send(new GetRoomCalendarQuery { Id = id }));
        }

        // GET: api/Room/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomViewModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetRoomDetailsQuery { Id = id }));
        }

        // POST: api/Room
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<RoomViewModel>> Create([FromBody]CreateRoomCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT: api/Room/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RoomViewModel>> Update(int id, [FromBody]UpdateRoomCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteRoomCommand { Id = id });

            return NoContent();
        }
    }
}
