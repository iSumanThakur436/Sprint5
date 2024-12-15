using MovieApplicationSprint.Entities;
using HandsOnAPIUsingEF.Repositories;
using MovieApplicationSprint.Entities;
using MovieApplicationSprint.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieApplicationSprint.Controllers
{
    public class TheaterController : ApiController
    {
        private ITheaterRepository repository;

        public TheaterController()
        {
            repository = new TheaterRepository();
        }

        [HttpPost, Route("AddTheater")]
        public IHttpActionResult Add([FromBody] Theater theater)
        {
            try
            {
                repository.AddTheater(theater);
                return Ok("Theater added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut, Route("UpdateTheater")]
        public IHttpActionResult Update([FromBody] Theater theater)
        {
            try
            {
                repository.UpdateTheater(theater);
                return Ok("Theater updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete, Route("DeleteTheater/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                repository.DeleteTheater(id);
                return Ok("Theater deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("GetTheaterById/{id}")]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var theater = repository.GetTheaterById(id);
                return Ok(theater);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("GetAllTheaters")]
        public IHttpActionResult GetAll()
        {
            try
            {
                var theaters = repository.GetAllTheaters();
                return Ok(theaters);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}