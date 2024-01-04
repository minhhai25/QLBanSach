using System;
using System.Collections.Generic;

namespace webBanSach.Models;

public partial class Tacgium
{
    public int Matg { get; set; }

    public string Tentg { get; set; } = null!;

    public DateTime? Ngaysinh { get; set; }

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}
