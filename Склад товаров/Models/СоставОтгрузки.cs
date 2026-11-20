using System;
using System.Collections.Generic;

namespace Склад_товаров.Models;

public partial class СоставОтгрузки
{
    public int КодСтрокиОтгрузки { get; set; }

    public int КодОтгрузки { get; set; }

    public int КодТовара { get; set; }

    public decimal Количество { get; set; }

    public virtual Отгрузки КодОтгрузкиNavigation { get; set; } = null!;

    public virtual Товары КодТовараNavigation { get; set; } = null!;
}
