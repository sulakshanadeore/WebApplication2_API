using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApplication2_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryRepo _repo;
        public CategoryController(ICategoryRepo repo)
        {
            _repo = repo;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<CategoryModel>> ShowAll()
        {
            return _repo.GetAll();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public CategoryModel Findcategory(int id)
        {
            return _repo.FindByCategoryID(id);  
        }


        [HttpGet("{id}/{name}")]
        public CategoryModel SearchByCategoryNameandCategoryID(int id, string name)
        {
            CategoryModel m = _repo.FindByIDAndName(id, name);
            return m;
        }

        // POST api/<CategoryController>
        [HttpPost]
        public HttpStatusCode Post([FromBody] CategoryModel category)
        {
            _repo.AddCategory(category);   
            
            return HttpStatusCode.Created;


        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
