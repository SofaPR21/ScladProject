using System;
using System.Collections.Generic;

namespace Склад_товаров.Models;

public partial class Товары
{
    public int КодТовара { get; set; }

    public string Наименование { get; set; } = null!;

    public string Артикул { get; set; } = null!;

    public int КодКатегории { get; set; }

    public string ЕдиницаИзмерения { get; set; } = null!;

    public decimal Количество { get; set; }

    public bool Активен { get; set; }

    public virtual Категории КодКатегорииNavigation { get; set; } = null!;

    public virtual ICollection<СоставОтгрузки> СоставОтгрузкиs { get; set; } = new List<СоставОтгрузки>();

    public virtual ICollection<СоставПоступления> СоставПоступленияs { get; set; } = new List<СоставПоступления>();
}
