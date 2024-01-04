using System;
using System.Collections.Generic;

namespace webBanSach.Models;

public partial class Ctsanpham
{
    public int Mactsp { get; set; }

    public int? Masp { get; set; }

    public string Ctthu { get; set; } = null!;

    public int Mactpnk { get; set; }

    public int? Mactdd { get; set; }

    public string Tinhtrang { get; set; } = null!;

    public string? Isbn { get; set; }

    public virtual Ctdd? MactddNavigation { get; set; }

    public virtual Ctpnkho MactpnkNavigation { get; set; } = null!;

    public virtual Sanpham? MaspNavigation { get; set; }
}
