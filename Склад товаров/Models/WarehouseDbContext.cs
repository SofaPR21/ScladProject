using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Склад_товаров.Models;

public partial class WarehouseDbContext : DbContext
{
    public WarehouseDbContext()
    {
    }

    public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Категории> Категорииs { get; set; }

    public virtual DbSet<Контрагенты> Контрагентыs { get; set; }

    public virtual DbSet<Отгрузки> Отгрузкиs { get; set; }

    public virtual DbSet<Пользователи> Пользователиs { get; set; }

    public virtual DbSet<Поступления> Поступленияs { get; set; }

    public virtual DbSet<Роли> Ролиs { get; set; }

    public virtual DbSet<СоставОтгрузки> СоставОтгрузкиs { get; set; }

    public virtual DbSet<СоставПоступления> СоставПоступленияs { get; set; }

    public virtual DbSet<Товары> Товарыs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HELLO_GLICH;Database=WarehouseDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Категории>(entity =>
        {
            entity.HasKey(e => e.КодКатегории).HasName("PK__Категори__6EEAA04B446E2D0B");

            entity.ToTable("Категории");

            entity.HasIndex(e => e.НазваниеКатегории, "UQ__Категори__C1D4E24838E6118C").IsUnique();

            entity.Property(e => e.НазваниеКатегории).HasMaxLength(100);
            entity.Property(e => e.Описание).HasMaxLength(300);
        });

        modelBuilder.Entity<Контрагенты>(entity =>
        {
            entity.HasKey(e => e.КодКонтрагента).HasName("PK__Контраге__2C526847D231A815");

            entity.ToTable("Контрагенты");

            entity.Property(e => e.Адрес).HasMaxLength(200);
            entity.Property(e => e.Наименование).HasMaxLength(150);
            entity.Property(e => e.Телефон).HasMaxLength(30);
            entity.Property(e => e.ТипКонтрагента).HasMaxLength(20);
            entity.Property(e => e.ЭлектроннаяПочта).HasMaxLength(100);
        });

        modelBuilder.Entity<Отгрузки>(entity =>
        {
            entity.HasKey(e => e.КодОтгрузки).HasName("PK__Отгрузки__37172088916DAE3E");

            entity.ToTable("Отгрузки");

            entity.HasIndex(e => e.НомерОтгрузки, "UQ__Отгрузки__01AF619F90BA650E").IsUnique();

            entity.Property(e => e.ДатаОтгрузки).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Комментарий).HasMaxLength(300);
            entity.Property(e => e.НомерОтгрузки).HasMaxLength(30);
            entity.Property(e => e.Статус)
                .HasMaxLength(20)
                .HasDefaultValue("Черновик");

            entity.HasOne(d => d.КодКонтрагентаNavigation).WithMany(p => p.Отгрузкиs)
                .HasForeignKey(d => d.КодКонтрагента)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Связь_Отгрузки_Контрагенты");

            entity.HasOne(d => d.КодПользователяNavigation).WithMany(p => p.Отгрузкиs)
                .HasForeignKey(d => d.КодПользователя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Связь_Отгрузки_Пользователи");
        });

        modelBuilder.Entity<Пользователи>(entity =>
        {
            entity.HasKey(e => e.КодПользователя).HasName("PK__Пользова__200434A2D629B92C");

            entity.ToTable("Пользователи");

            entity.HasIndex(e => e.Логин, "UQ__Пользова__BC2217D3044F47D0").IsUnique();

            entity.Property(e => e.Активен).HasDefaultValue(true);
            entity.Property(e => e.ДатаСоздания).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Логин).HasMaxLength(50);
            entity.Property(e => e.Фио)
                .HasMaxLength(100)
                .HasColumnName("ФИО");
            entity.Property(e => e.ХешПароля).HasMaxLength(255);

            entity.HasOne(d => d.КодРолиNavigation).WithMany(p => p.Пользователиs)
                .HasForeignKey(d => d.КодРоли)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Связь_Пользователи_Роли");
        });

        modelBuilder.Entity<Поступления>(entity =>
        {
            entity.HasKey(e => e.КодПоступления).HasName("PK__Поступле__20DEFAA1603F229D");

            entity.ToTable("Поступления");

            entity.HasIndex(e => e.НомерПоступления, "UQ__Поступле__8471F634EFB89E0A").IsUnique();

            entity.Property(e => e.ДатаПоступления).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Комментарий).HasMaxLength(300);
            entity.Property(e => e.НомерПоступления).HasMaxLength(30);
            entity.Property(e => e.Статус)
                .HasMaxLength(20)
                .HasDefaultValue("Черновик");

            entity.HasOne(d => d.КодКонтрагентаNavigation).WithMany(p => p.Поступленияs)
                .HasForeignKey(d => d.КодКонтрагента)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Связь_Поступления_Контрагенты");

            entity.HasOne(d => d.КодПользователяNavigation).WithMany(p => p.Поступленияs)
                .HasForeignKey(d => d.КодПользователя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Связь_Поступления_Пользователи");
        });

        modelBuilder.Entity<Роли>(entity =>
        {
            entity.HasKey(e => e.КодРоли).HasName("PK__Роли__A2517212B873C3EE");

            entity.ToTable("Роли");

            entity.HasIndex(e => e.НазваниеРоли, "UQ__Роли__B867938EA331ABFF").IsUnique();

            entity.Property(e => e.НазваниеРоли).HasMaxLength(30);
        });

        modelBuilder.Entity<СоставОтгрузки>(entity =>
        {
            entity.HasKey(e => e.КодСтрокиОтгрузки).HasName("PK__СоставОт__39AE78C238A45E96");

            entity.ToTable("СоставОтгрузки");

            entity.HasIndex(e => new { e.КодОтгрузки, e.КодТовара }, "Уникальность_ТовараВОгрузке").IsUnique();

            entity.Property(e => e.Количество).HasColumnType("decimal(18, 3)");

            entity.HasOne(d => d.КодОтгрузкиNavigation).WithMany(p => p.СоставОтгрузкиs)
                .HasForeignKey(d => d.КодОтгрузки)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Связь_СоставОтгрузки_Отгрузки");

            entity.HasOne(d => d.КодТовараNavigation).WithMany(p => p.СоставОтгрузкиs)
                .HasForeignKey(d => d.КодТовара)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Связь_СоставОтгрузки_Товары");
        });

        modelBuilder.Entity<СоставПоступления>(entity =>
        {
            entity.HasKey(e => e.КодСтрокиПоступления).HasName("PK__СоставПо__0388648738BDA1E3");

            entity.ToTable("СоставПоступления");

            entity.HasIndex(e => new { e.КодПоступления, e.КодТовара }, "Уникальность_ТовараВПоступлении").IsUnique();

            entity.Property(e => e.Количество).HasColumnType("decimal(18, 3)");

            entity.HasOne(d => d.КодПоступленияNavigation).WithMany(p => p.СоставПоступленияs)
                .HasForeignKey(d => d.КодПоступления)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Связь_СоставПоступления_Поступления");

            entity.HasOne(d => d.КодТовараNavigation).WithMany(p => p.СоставПоступленияs)
                .HasForeignKey(d => d.КодТовара)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Связь_СоставПоступления_Товары");
        });

        modelBuilder.Entity<Товары>(entity =>
        {
            entity.HasKey(e => e.КодТовара).HasName("PK__Товары__02FE99B3E1E329A7");

            entity.ToTable("Товары");

            entity.HasIndex(e => e.Артикул, "UQ__Товары__F333AABF06F257B7").IsUnique();

            entity.Property(e => e.Активен).HasDefaultValue(true);
            entity.Property(e => e.Артикул).HasMaxLength(50);
            entity.Property(e => e.ЕдиницаИзмерения).HasMaxLength(20);
            entity.Property(e => e.Количество).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Наименование).HasMaxLength(100);

            entity.HasOne(d => d.КодКатегорииNavigation).WithMany(p => p.Товарыs)
                .HasForeignKey(d => d.КодКатегории)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Связь_Товары_Категории");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
