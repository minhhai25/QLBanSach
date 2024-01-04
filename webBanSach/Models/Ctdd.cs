using System;
using System.Collections.Generic;

namespace webBanSach.Models;

public partial class Ctdd
{
    public int Mactdd { get; set; }

    public int? Madd { get; set; }

    public int? Masp { get; set; }

    public int Sldat { get; set; }

    public decimal Thanhtien { get; set; }

    public string? Ghichu { get; set; }

    public virtual ICollection<Ctsanpham> Ctsanphams { get; set; } = new List<Ctsanpham>();

    public virtual Dondat? MaddNavigation { get; set; }

    public virtual Sanpham? MaspNavigation { get; set; }
}
