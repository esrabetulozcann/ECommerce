namespace ECommerce.Core.Models.Response.Categories
{
    public class CategoryResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }
    }
}
