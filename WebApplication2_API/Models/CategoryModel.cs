using System.ComponentModel.DataAnnotations;

namespace WebApplication2_API.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }

   public interface ICategoryRepo
    {
        List<CategoryModel> GetAll();

        CategoryModel FindByCategoryID(int id);

        CategoryModel FindByIDAndName(int id,string name);  


        void AddCategory(CategoryModel category);
    }
    public class CategoryRepo : ICategoryRepo
    {
        NorthwindDataContext _context;
        public CategoryRepo(NorthwindDataContext context)
        {
            _context = context;
        }



      public  void AddCategory(CategoryModel category)
        { 
        _context.Categories.Add(category);  
        _context.SaveChanges();
        }


        public CategoryModel FindByIDAndName(int id, string name)
        {
            CategoryModel model=_context.Categories.Where(c => c.CategoryID == id && c.CategoryName == name)
                .FirstOrDefault();
            return model;   
        
        
        }
        public CategoryModel FindByCategoryID(int id)
        {
            return _context.Categories.Find(id);
        }

        public List<CategoryModel> GetAll()
        {

            return _context.Categories.ToList();
        }
    }
}