using System;
using System.Collections.Generic;

namespace webBanSach.Models;

public partial class Taikhoan
{
    public int Matk { get; set; }

    public string Tendn { get; set; } = null!;

    public string Matkhau { get; set; } = null!;

    public string? Loaitk { get; set; }

    public string? Dienthoai { get; set; }

    public virtual ICollection<Dondat> Dondats { get; set; } = new List<Dondat>();

    public virtual ICollection<Pnkho> Pnkhos { get; set; } = new List<Pnkho>();
}
