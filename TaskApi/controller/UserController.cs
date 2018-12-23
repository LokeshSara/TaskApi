using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskApi.Model;
using TaskApi.repository;

namespace TaskApi.controller
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private IUserRepository _repository;

        public UserController(IUserRepository repo)
        {
            _repository = repo;
        }


        [HttpGet("")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var user = _repository.GetAllUsers();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


          


        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var users = _repository.GetUserById(id);

         

            return Ok(users);
        }

        [HttpPost("search")]
        public IActionResult Search([FromBody] UserSearchOption searchoption)
        {


            var users = _repository.SerachUser(searchoption);

        

            return Ok(users);
        }

        [HttpPost("add")]
        public IActionResult AddUser([FromBody] UserDTO userDtoInfo)
        {
          

            var user = new Entity.User {
                   EmployeeId = userDtoInfo.EmployeeId,
                    FirstName = userDtoInfo.FirstName ,
                     LastName = userDtoInfo.LastName
            };

            _repository.AddUser(user);



            return Ok(true);
        }

        [HttpPost("update")]
        public IActionResult UpdateUser([FromBody] UserDTO userDtoInfo)
        {

            var user = new Entity.User
            {
                UserId = userDtoInfo.UserId,
                EmployeeId = userDtoInfo.EmployeeId,
                FirstName = userDtoInfo.FirstName,
                LastName = userDtoInfo.LastName
            };

            _repository.UpdateUser(user);



            return Ok(true);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {


            _repository.DeleteUser(id);



            return Ok(true);
        }





        [HttpGet("Ping")]
        public IActionResult PingTest()
        {
            var tasks = "Success!!!";
            return Ok(tasks);
        }

    }
}
