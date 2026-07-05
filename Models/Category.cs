using System.ComponentModel.DataAnnotations;

namespace LaptopStore.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên danh mục")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public ICollection<Laptop> Laptops { get; set; } = new List<Laptop>();
    }
}