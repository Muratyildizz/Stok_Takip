using System.ComponentModel.DataAnnotations;

namespace Stok_Takip.Models;

public class Urun
{
    [Key]
  public int UrunId { get; set; }
  public string UrunName { get; set;}
  public int UrunCategory { get; set; }
  public decimal UrunPrice { get; set; }
  public int Stok {get; set;}
}
