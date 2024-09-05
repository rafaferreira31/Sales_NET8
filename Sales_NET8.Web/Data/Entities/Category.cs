using System.ComponentModel.DataAnnotations;

namespace Sales_NET8.Web.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name="Categoria")]
        [Required]
        public string? Name { get; set; }
    }
}
