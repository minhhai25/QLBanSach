using System;
using System.Collections.Generic;

namespace webBanSach.Models;

public partial class Sanpham
{
    public int Masp { get; set; }

    public string Tensp { get; set; } = null!;

    public int? Manxb { get; set; }

    public int? Maloai { get; set; }

    public int? Matg { get; set; }

    public int Gia { get; set; }

    public string? Mota { get; set; }

    public virtual ICollection<Ctdd> Ctdds { get; set; } = new List<Ctdd>();

    public virtual ICollection<Ctpnkho> Ctpnkhos { get; set; } = new List<Ctpnkho>();

    public virtual ICollection<Ctsanpham> Ctsanphams { get; set; } = new List<Ctsanpham>();

    public virtual Loai? MaloaiNavigation { get; set; }

    public virtual Nxb? ManxbNavigation { get; set; }

    public virtual Tacgium? MatgNavigation { get; set; }
}
