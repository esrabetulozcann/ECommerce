namespace ECommerce.Core.Models.Response.Sizes
{
    public class SizeResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SizeTypeResponseModel SizeType { get; set; }
    }
}
