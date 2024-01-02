using System.ComponentModel.DataAnnotations;

namespace Stok_Takip.Models;

public class Login
{
    public int Id { get; set; }
    public string KullanıcıName { get; set; }
    public string Sifre { get; set; }
}
