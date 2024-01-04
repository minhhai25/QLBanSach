using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webBanSach.Models;

public partial class WebqlbansachContext : DbContext
{
    public WebqlbansachContext()
    {
    }

    public WebqlbansachContext(DbContextOptions<WebqlbansachContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ctdd> Ctdds { get; set; }

    public virtual DbSet<Ctpnkho> Ctpnkhos { get; set; }

    public virtual DbSet<Ctsanpham> Ctsanphams { get; set; }

    public virtual DbSet<Dondat> Dondats { get; set; }

    public virtual DbSet<Loai> Loais { get; set; }

    public virtual DbSet<Nxb> Nxbs { get; set; }

    public virtual DbSet<Pnkho> Pnkhos { get; set; }

    public virtual DbSet<Sanpham> Sanphams { get; set; }

    public virtual DbSet<Tacgium> Tacgia { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-OOQJGOT\\SQLEXPRESS;Initial Catalog=WEBQLBANSACH;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ctdd>(entity =>
        {
            entity.HasKey(e => e.Mactdd).HasName("PK__CTDD__F50D554E25F72EB1");

            entity.ToTable("CTDD");

            entity.Property(e => e.Mactdd).HasColumnName("MACTDD");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(100)
                .HasColumnName("GHICHU");
            entity.Property(e => e.Madd).HasColumnName("MADD");
            entity.Property(e => e.Masp).HasColumnName("MASP");
            entity.Property(e => e.Sldat).HasColumnName("SLDAT");
            entity.Property(e => e.Thanhtien)
                .HasColumnType("money")
                .HasColumnName("THANHTIEN");

            entity.HasOne(d => d.MaddNavigation).WithMany(p => p.Ctdds)
                .HasForeignKey(d => d.Madd)
                .HasConstraintName("FK__CTDD__MADD__628FA481");

            entity.HasOne(d => d.MaspNavigation).WithMany(p => p.Ctdds)
                .HasForeignKey(d => d.Masp)
                .HasConstraintName("FK__CTDD__MASP__6383C8BA");
        });

        modelBuilder.Entity<Ctpnkho>(entity =>
        {
            entity.HasKey(e => e.Mactpnk).HasName("PK__CTPNKHO__BFAD1336134F20B7");

            entity.ToTable("CTPNKHO");

            entity.HasIndex(e => new { e.Masp, e.Mapnk }, "cttiet_pnk_unique").IsUnique();

            entity.Property(e => e.Mactpnk).HasColumnName("MACTPNK");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(100)
                .HasColumnName("GHICHU");
            entity.Property(e => e.Mapnk).HasColumnName("MAPNK");
            entity.Property(e => e.Masp).HasColumnName("MASP");
            entity.Property(e => e.Slnhap).HasColumnName("SLNHAP");
            entity.Property(e => e.Thanhtien)
                .HasColumnType("money")
                .HasColumnName("THANHTIEN");

            entity.HasOne(d => d.MapnkNavigation).WithMany(p => p.Ctpnkhos)
                .HasForeignKey(d => d.Mapnk)
                .HasConstraintName("FK__CTPNKHO__MAPNK__5BE2A6F2");

            entity.HasOne(d => d.MaspNavigation).WithMany(p => p.Ctpnkhos)
                .HasForeignKey(d => d.Masp)
                .HasConstraintName("FK__CTPNKHO__MASP__5AEE82B9");
        });

        modelBuilder.Entity<Ctsanpham>(entity =>
        {
            entity.HasKey(e => e.Mactsp).HasName("PK__CTSANPHA__F501C2F5898D05A4");

            entity.ToTable("CTSANPHAM");

            entity.Property(e => e.Mactsp).HasColumnName("MACTSP");
            entity.Property(e => e.Ctthu)
                .HasMaxLength(100)
                .HasColumnName("CTTHU");
            entity.Property(e => e.Isbn)
                .HasMaxLength(100)
                .HasColumnName("ISBN");
            entity.Property(e => e.Mactdd).HasColumnName("MACTDD");
            entity.Property(e => e.Mactpnk).HasColumnName("MACTPNK");
            entity.Property(e => e.Masp).HasColumnName("MASP");
            entity.Property(e => e.Tinhtrang)
                .HasMaxLength(100)
                .HasColumnName("TINHTRANG");

            entity.HasOne(d => d.MactddNavigation).WithMany(p => p.Ctsanphams)
                .HasForeignKey(d => d.Mactdd)
                .HasConstraintName("FK__CTSANPHAM__MACTD__693CA210");

            entity.HasOne(d => d.MactpnkNavigation).WithMany(p => p.Ctsanphams)
                .HasForeignKey(d => d.Mactpnk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CTSANPHAM__MACTP__68487DD7");

            entity.HasOne(d => d.MaspNavigation).WithMany(p => p.Ctsanphams)
                .HasForeignKey(d => d.Masp)
                .HasConstraintName("FK__CTSANPHAM__MASP__6754599E");
        });

        modelBuilder.Entity<Dondat>(entity =>
        {
            entity.HasKey(e => e.Madd).HasName("PK__DONDAT__603F004B920F29F2");

            entity.ToTable("DONDAT");

            entity.Property(e => e.Madd).HasColumnName("MADD");
            entity.Property(e => e.Matk).HasColumnName("MATK");
            entity.Property(e => e.Thoigian)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("THOIGIAN");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(100)
                .HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.MatkNavigation).WithMany(p => p.Dondats)
                .HasForeignKey(d => d.Matk)
                .HasConstraintName("FK__DONDAT__MATK__5EBF139D");
        });

        modelBuilder.Entity<Loai>(entity =>
        {
            entity.HasKey(e => e.Maloai).HasName("PK_LOAI_MALOAI");

            entity.ToTable("LOAI");

            entity.Property(e => e.Maloai).HasColumnName("MALOAI");
            entity.Property(e => e.Tenloai)
                .HasMaxLength(100)
                .HasColumnName("TENLOAI");
        });

        modelBuilder.Entity<Nxb>(entity =>
        {
            entity.HasKey(e => e.Manxb).HasName("PK_NXB_MANXB");

            entity.ToTable("NXB");

            entity.Property(e => e.Manxb).HasColumnName("MANXB");
            entity.Property(e => e.Namxb)
                .HasColumnType("datetime")
                .HasColumnName("NAMXB");
            entity.Property(e => e.Tennxb)
                .HasMaxLength(100)
                .HasColumnName("TENNXB");
        });

        modelBuilder.Entity<Pnkho>(entity =>
        {
            entity.HasKey(e => e.Mapnk).HasName("PK__PNKHO__7B35EB50FF9A43B4");

            entity.ToTable("PNKHO");

            entity.Property(e => e.Mapnk).HasColumnName("MAPNK");
            entity.Property(e => e.Matk).HasColumnName("MATK");
            entity.Property(e => e.Ngaygio)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("NGAYGIO");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(100)
                .HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.MatkNavigation).WithMany(p => p.Pnkhos)
                .HasForeignKey(d => d.Matk)
                .HasConstraintName("FK__PNKHO__MATK__5165187F");
        });

        modelBuilder.Entity<Sanpham>(entity =>
        {
            entity.HasKey(e => e.Masp).HasName("PK__SANPHAM__60228A32506093C0");

            entity.ToTable("SANPHAM");

            entity.Property(e => e.Masp).HasColumnName("MASP");
            entity.Property(e => e.Gia).HasColumnName("GIA");
            entity.Property(e => e.Maloai).HasColumnName("MALOAI");
            entity.Property(e => e.Manxb).HasColumnName("MANXB");
            entity.Property(e => e.Matg).HasColumnName("MATG");
            entity.Property(e => e.Mota)
                .HasMaxLength(500)
                .HasColumnName("MOTA");
            entity.Property(e => e.Tensp)
                .HasMaxLength(100)
                .HasColumnName("TENSP");

            entity.HasOne(d => d.MaloaiNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.Maloai)
                .HasConstraintName("FK__SANPHAM__MALOAI__5629CD9C");

            entity.HasOne(d => d.ManxbNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.Manxb)
                .HasConstraintName("FK__SANPHAM__MANXB__5535A963");

            entity.HasOne(d => d.MatgNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.Matg)
                .HasConstraintName("FK__SANPHAM__MATG__571DF1D5");
        });

        modelBuilder.Entity<Tacgium>(entity =>
        {
            entity.HasKey(e => e.Matg).HasName("PK_TACGIA_MATG");

            entity.ToTable("TACGIA");

            entity.Property(e => e.Matg).HasColumnName("MATG");
            entity.Property(e => e.Ngaysinh)
                .HasColumnType("datetime")
                .HasColumnName("NGAYSINH");
            entity.Property(e => e.Tentg)
                .HasMaxLength(100)
                .HasColumnName("TENTG");
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.Matk);

            entity.ToTable("TAIKHOAN");

            entity.Property(e => e.Matk).HasColumnName("MATK");
            entity.Property(e => e.Dienthoai)
                .HasMaxLength(20)
                .HasColumnName("DIENTHOAI");
            entity.Property(e => e.Loaitk)
                .HasMaxLength(50)
                .HasColumnName("LOAITK");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(50)
                .HasColumnName("MATKHAU");
            entity.Property(e => e.Tendn)
                .HasMaxLength(100)
                .HasColumnName("TENDN");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
