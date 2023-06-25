namespace MSSQLVeritabaniIslemleri.Models
{
    public class ProductAddModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IFormFile File { get; set; }
    }
}
