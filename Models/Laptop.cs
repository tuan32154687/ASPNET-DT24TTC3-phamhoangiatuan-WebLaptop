using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopStore.Models
{
    public class Laptop
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên laptop không được để trống")]
        public string Name { get; set; } = string.Empty;

        public string? Brand { get; set; }
        public string? Cpu { get; set; }
        public string? Ram { get; set; }
        public string? Storage { get; set; }
        public string? Gpu { get; set; }
        public string? ScreenSize { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Giá tiền không hợp lệ")]
        public decimal Price { get; set; }

        public int Stock { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }

       
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}