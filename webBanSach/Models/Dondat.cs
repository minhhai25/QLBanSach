using System;
using System.Collections.Generic;

namespace webBanSach.Models;

public partial class Dondat
{
    public int Madd { get; set; }

    public int? Matk { get; set; }

    public DateTime Thoigian { get; set; }

    public string Trangthai { get; set; } = null!;

    public virtual ICollection<Ctdd> Ctdds { get; set; } = new List<Ctdd>();

    public virtual Taikhoan? MatkNavigation { get; set; }
}
