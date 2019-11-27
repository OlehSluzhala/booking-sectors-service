using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftServe.BookingSectors.WebAPI.Data.GenericRepository;
using SoftServe.BookingSectors.WebAPI.Data.Models;


namespace SoftServe.BookingSectors.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        ////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Репозиторій потрібно для створення. І наша таблиця
        /// </summary>
        GenericRepository<User> repository = null;


        /// <summary>
        /// І конструктор створити
        /// </summary>
        public TestController()
        {
            repository = new GenericRepository<User>();
        }

        /// Отак отримувати дані

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return repository.GetAll();
        }



        /////////////////////////////////////////////////////////////////////







        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
