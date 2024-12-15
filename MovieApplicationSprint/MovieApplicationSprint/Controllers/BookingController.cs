using MovieApplicationSprint.Entities;
using MovieApplicationSprint.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieApplicationSprint.Controllers
{
    [RoutePrefix("api/Booking")]
    public class BookingController : ApiController
    {

        private readonly IBookingRepository _repository;

        public BookingController()
        {
            _repository = new BookingRepository();
        }

        [HttpPost, Route("Create")]
        public IHttpActionResult Create([FromBody] Booking booking)
        {
            try
            {
                _repository.CreateBooking(booking);
                return Ok("Booking created successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("GetAll")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var bookings = _repository.GetAllBookings();
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("GetById/{id}")]
        
        public IHttpActionResult GetById(string id)
        {
            try
            {
                var booking = _repository.GetBookingById(id);
                if (booking == null)
                {
                    return NotFound();
                }

                // Return user details as part of the response
                var result = new
                {
                    BookingId = booking.BookingId,
                    BookingDate = booking.BookingDate,
                    TotalPrice = booking.TotalPrice,
                    Status = booking.Status,
                    User = new
                    {
                        UserId = booking.UserNavigation.UserId,
                        UserName = booking.UserNavigation.UserName,
                        Email = booking.UserNavigation.Email,
                        Mobile = booking.UserNavigation.Mobile
                    }
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet, Route("GetByUser/{userId}")]
        public IHttpActionResult GetByUser(string userId)
        {
            try
            {
                var bookings = _repository.GetBookingsByUser(userId);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete, Route("Cancel/{id}")]
        public IHttpActionResult Cancel(string id)
        {
            try
            {
                _repository.CancelBooking(id);
                return Ok("Booking cancelled successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
