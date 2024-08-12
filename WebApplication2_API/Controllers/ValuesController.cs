using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApplication2_API.Models;

namespace WebApplication2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        ICategoryRepo _repo;
        public ValuesController(ICategoryRepo repo)
        {
            _repo = repo;
        }

        [HttpGet()]
        public async Task<List<CategoryModel>> GetAllCategroies()
        {
            await Task.Delay(1000);
            List<CategoryModel> model = _repo.GetAll();
            return model;
        }

        //        [Route("{id}")]
        [HttpGet("{id}")]
       public async Task<CategoryModel> CategorySearchById(int id)
        {
            await Task.Delay(1000);
            return _repo.FindByCategoryID(id);

        }
        [HttpGet("{id}/{name}")]
        public CategoryModel SearchByCategoryNameandCategoryID(int id,string name)
        {
            CategoryModel m=_repo.FindByIDAndName(id, name);
            return m;
        }





        public async Task<CategoryModel> CategorySearchByIdAndName(int id,string Name)
        {
            await Task.Delay(1000);
            return _repo.FindByCategoryID(id);

        }

    }
}
