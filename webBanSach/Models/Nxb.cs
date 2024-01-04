using System;
using System.Collections.Generic;

namespace webBanSach.Models;

public partial class Nxb
{
    public int Manxb { get; set; }

    public string Tennxb { get; set; } = null!;

    public DateTime Namxb { get; set; }

    public virtual ICollection<Sanpham> Sanphams { get; set; } = new List<Sanpham>();
}
