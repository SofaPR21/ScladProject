using System;
using System.Collections.Generic;

namespace Склад_товаров.Models;

public partial class СоставПоступления
{
    public int КодСтрокиПоступления { get; set; }

    public int КодПоступления { get; set; }

    public int КодТовара { get; set; }

    public decimal Количество { get; set; }

    public virtual Поступления КодПоступленияNavigation { get; set; } = null!;

    public virtual Товары КодТовараNavigation { get; set; } = null!;
}
