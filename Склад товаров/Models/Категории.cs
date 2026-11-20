using System;
using System.Collections.Generic;

namespace Склад_товаров.Models;

public partial class Категории
{
    public int КодКатегории { get; set; }

    public string НазваниеКатегории { get; set; } = null!;

    public string? Описание { get; set; }

    public virtual ICollection<Товары> Товарыs { get; set; } = new List<Товары>();
}
