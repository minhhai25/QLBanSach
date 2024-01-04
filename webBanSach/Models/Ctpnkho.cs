using System;
using System.Collections.Generic;

namespace webBanSach.Models;

public partial class Ctpnkho
{
    public int Mactpnk { get; set; }

    public int? Masp { get; set; }

    public int? Mapnk { get; set; }

    public int Slnhap { get; set; }

    public decimal Thanhtien { get; set; }

    public string? Ghichu { get; set; }

    public virtual ICollection<Ctsanpham> Ctsanphams { get; set; } = new List<Ctsanpham>();

    public virtual Pnkho? MapnkNavigation { get; set; }

    public virtual Sanpham? MaspNavigation { get; set; }
}
