using System.ComponentModel.DataAnnotations;

namespace Stok_Takip.Models;

public class Category
{
    
    public int CategoryId { get; set; }

    [Required(ErrorMessage ="Kategori Adı giriniz!")]
    public string CategoryName { get; set; }

}
