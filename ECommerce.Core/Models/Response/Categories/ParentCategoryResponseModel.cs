namespace ECommerce.Core.Models.Response.Categories
{
    public class ParentCategoryResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CategoryResponseModel> Category { get; set; }


    }
}
