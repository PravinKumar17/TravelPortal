﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAPI.Models;
using TravelAPI.Services;

namespace TravelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCors")]

    public class RequestController : ControllerBase
    {
        private readonly RequestServices _repo;

        public RequestController(RequestServices repo)
        {
            _repo = repo;
        }

        [HttpPost]
        [Route("Employee")]

        public async Task<ActionResult<Request>> Employee(Request user)
        {
            var emp = await _repo.Employee(user);
            if (emp == null)
            {
                return BadRequest("Some thing is rong please try later");
            }
            return Created("Approve Manager", emp);
        }


        [HttpPost]
        [Route("Manager")]

        public async Task<ActionResult<Request>> Create(Request user)
        {
            var emp =await _repo.Manager(user);
            if (emp == null)
            {
                return BadRequest("Some thing is rong please try later");
            }
            return Created("Approve Manager", emp);
        }

        [HttpPost]
        [Route("DepartmentHead")]

        public async Task<ActionResult<Request>> DeptHead(Request user)
        {
            var emp =await _repo.DeptHead(user);
            if (emp == null)
            {
                return BadRequest("Some thing is rong please try later");
            }
            return Created("Approve Manager", emp);
        }

        [HttpPost]
        [Route("Facilityapprovel")]

        public async Task<ActionResult<Request>> facilityapprovel(Request user)
        {
            var emp = await _repo.facilityapprovel(user);
            if (emp == null)
            {
                return BadRequest("Some thing is rong please try later");
            }
            return Created("Approve Manager", emp);
        }

        [HttpPost]
        [Route("Facility")]

        public async Task<ActionResult<Request>> Facility(Request user)
        {
            var emp =await _repo.Facility(user);
            if (emp == null)
            {
                return BadRequest("Some thing is rong please try later");
            }
            return Created("Approve Manager", emp);
        }

     
     
        [HttpGet]
        [Route("GetAll_Manager")]

        public async Task<ActionResult<IEnumerable<User>>> GetAllManager()
        {
            var prd = _repo.GetAllManager().ToList();
            if (prd.Count == 0)
                return NotFound("No Employee present");
            return Ok(prd);
        }

        [HttpGet]
        [Route("GetAll_Head")]

        public async Task<ActionResult<IEnumerable<User>>> GetAllHead()
        {
            var prd = _repo.GetAllHead().ToList();
            if (prd.Count == 0)
                return NotFound("No Employee present");
            return Ok(prd);
        }

        [HttpGet]
        [Route("GetAll_Facility")]

        public async Task<ActionResult<IEnumerable<User>>> GetAllFacility()
        {
            var prd = _repo.GetAllfacility().ToList();
            if (prd.Count == 0)
                return NotFound("No Employee present");
            return Ok(prd);
        }

        [HttpPost]
        [Route("getbyidfacility")]

        public async Task<ActionResult<IEnumerable<Request>>> getbyidfacility(Request user)
        {
            var emp = _repo.getbyidfacility(user).ToList();
            if (emp == null)
            {
                return BadRequest("Some thing is rong please try later");
            }
            return Created("Approve Manager", emp);
        }

        [HttpGet]
        [Route("GetAll_Travel")]

        public async Task<ActionResult<IEnumerable<User>>> GetAllProducts()
        {
            var prd = _repo.GetAll().ToList();
            if (prd.Count == 0)
                return NotFound("No Employee present");
            return Ok(prd);
        }

        [HttpPost]
        [Route("EmployeebyId")]

        public async Task<ActionResult<IEnumerable<Request>>> EmployeebyId(Request user)
        {
            var emp =  _repo.EmployeebyId(user).ToList();
            if (emp == null)
            {
                return BadRequest("Some thing is rong please try later");
            }
            return Created("Approve Manager", emp);
        }

        [HttpGet]
        [Route("GetAllPosttravel")]

        public async Task<ActionResult<IEnumerable<User>>> GetAllPosttravel()
        {
            var prd = _repo.GetAllPosttravel().ToList();
            if (prd.Count == 0)
                return NotFound("No Employee present");
            return Ok(prd);
        }
        
        [HttpPost]
        [Route("PostEmployeebyId")]

        public async Task<ActionResult<IEnumerable<Request>>> postEmployeebyId(Request user)
        {
            var emp = _repo.postEmployeebyId(user).ToList();
            if (emp == null)
            {
                return BadRequest("Some thing is rong please try later");
            }
            return Created("Approve Manager", emp);
        }

    }
}