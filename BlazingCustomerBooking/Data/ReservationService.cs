using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazingCustomerBooking.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationService : ControllerBase
    {
        private dat154_2022_42Context _ctx;
        public ReservationService(dat154_2022_42Context ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public Task<Reservation[]?> GetAllReservations()
        {
            return Task.FromResult(_ctx?.Reservations?.ToArray());
        }

        [HttpGet("AvailableRooms")]
        public Task<Room[]?> GetAvailableRooms(DateTime start, DateTime end)
        {
            // TODO: Move this data into the function parameters
          
           // DateTime start = DateTime.Today;
           // DateTime end = DateTime.Now;

            // This returned errors
            //return Task.FromResult(Library.Controller.GetAvailableRooms(_ctx, 1, 1, DateTime.Now, DateTime.Now)?.ToArray());

            // This can certainly be improved, but is a decent startingpoint.
            return Task.FromResult(_ctx?.Rooms?
                .Where(room => !room.Reservations
                    .Any(reservation => reservation.DateStart >= start && reservation.DateStart < end // If there is a reserved start date that's in between the requested start and end date.
                    || reservation.DateStart < start && reservation.DateEnd > start // If there is a reservation that starts before the start date but ends after the start date.
                    || reservation.DateStart < end && reservation.DateEnd >= end)) // If there is a reservation that starts before the end date but ends after the end date.
                .ToArray());
        }

        public Task<Reservation> CreateReservation(Room? room)
        {
            return 
           // TODO: Add reservation logic given a room (might need more parameters to make a full reservation?
        }
    }
}