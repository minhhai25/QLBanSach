using System;
using System.Collections.Generic;

namespace webBanSach.Models;

public partial class Pnkho
{
    public int Mapnk { get; set; }

    public int? Matk { get; set; }

    public DateTime? Ngaygio { get; set; }

    public string? Trangthai { get; set; }

    public virtual ICollection<Ctpnkho> Ctpnkhos { get; set; } = new List<Ctpnkho>();

    public virtual Taikhoan? MatkNavigation { get; set; }
}
