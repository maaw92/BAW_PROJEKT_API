using Core_Api_Test.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core_Api_Test.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly DefaultDbContext _db;

        public MoviesController(DefaultDbContext db)
        {
            _db = db;
        }

        [HttpGet("get")]        
        public IActionResult GetMovies()
        {            
            var movies = _db.MovieEvents.Select(e => new {e.Id, e.Name, e.Date}).ToList();
            return Ok(movies);
        }
        [HttpGet("getExistingReservations")]
        public IActionResult GetExistingReservations()
        {
            int userId = int.Parse(GetUserClaims().Single(x => x.Type.EndsWith("/identity/claims/sid")).Value);
            var movies = _db.Seats.Where(x => x.IsReserved && x.Reservations.Any(x => x.UserID.Equals(userId)))
                .Select(x => new { SeatNo = x.SeatNumber, Name = x.Event.Name, Date = x.Event.Date }).ToList();                
            return Ok(movies);
        }
        [HttpGet("{id}/seats")]
        public IActionResult GetSeats(int id)
        {
            var seats = _db.Seats.Where(s => s.EventId == id && !s.IsReserved).Select(s => new { s.Id, s.SeatNumber }).ToList();
            return Ok(seats);
        }
        [HttpPost("{seatId}/reserve")]
        public IActionResult Reserve([FromBody] ReservationRequest request)
        {            
            Seat? seat = _db.Seats.SingleOrDefault(s => s.Id == request.SeatId);
            if (seat == null || _db.Reservations.Any(r => r.SeatId == request.SeatId))
                return NotFound("Error.");
            //var test= GetUserClaims().Single(x => x.Type.EndsWith("/identity/claims/sid"));
            seat.IsReserved = true;
            SeatReservation reservation = new SeatReservation() { Seat = seat, SeatId = request.SeatId, UserID = int.Parse(GetUserClaims().Single(x => x.Type.EndsWith("/identity/claims/sid")).Value) };
            _db.Reservations.Add(reservation);
            _db.SaveChanges();
            return Ok("Zarezerwowano miejsce.");
        }
        [HttpPost("create")]
        public IActionResult CreateEvent([FromBody] CreateMovieRequest request)
        {
            MovieEvent ev = new MovieEvent() { Name = request.MovieName, Date = request.MovieDate,
                Seats = new List<Seat>() {
                    new Seat() { IsReserved = false, SeatNumber = "A1"},
                    new Seat() { IsReserved = false, SeatNumber = "A2"},
                    new Seat() { IsReserved = false, SeatNumber = "A3"},
                    new Seat() { IsReserved = false, SeatNumber = "A4"},
                    new Seat() { IsReserved = false, SeatNumber = "A5"},
                }
            };
            _db.MovieEvents.Add(ev);
            _db.SaveChanges();
            return Ok("Utworzono zdarzenie.");
        }
        private List<Claim> GetUserClaims()
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwt = handler.ReadJwtToken(HttpContext.Request.Headers["Authorization"].Single().Replace("Bearer ", ""));
            //foreach(var cl in jwt.Claims.ToList())
            //{
            //    System.Diagnostics.Debug.WriteLine(cl.Type);
            //}
            return jwt.Claims.ToList();

        }
    }

}
