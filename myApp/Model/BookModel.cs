using System.ComponentModel.DataAnnotations;

namespace myApp.Model
{
    public class BookModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int BoookId { get; set; }

        public double Price { get; set; }
        [Range(0, 100)]

        public int Quantity { get; set; }
    }
}
