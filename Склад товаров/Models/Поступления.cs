using System;
using System.Collections.Generic;

namespace Склад_товаров.Models;

public partial class Поступления
{
    public int КодПоступления { get; set; }

    public string НомерПоступления { get; set; } = null!;

    public int КодКонтрагента { get; set; }

    public int КодПользователя { get; set; }

    public DateTime ДатаПоступления { get; set; }

    public string Статус { get; set; } = null!;

    public string? Комментарий { get; set; }

    public virtual Контрагенты КодКонтрагентаNavigation { get; set; } = null!;

    public virtual Пользователи КодПользователяNavigation { get; set; } = null!;

    public virtual ICollection<СоставПоступления> СоставПоступленияs { get; set; } = new List<СоставПоступления>();
}
