using System;
using System.Collections.Generic;

namespace Склад_товаров.Models;

public partial class Отгрузки
{
    public int КодОтгрузки { get; set; }

    public string НомерОтгрузки { get; set; } = null!;

    public int КодКонтрагента { get; set; }

    public int КодПользователя { get; set; }

    public DateTime ДатаОтгрузки { get; set; }

    public string Статус { get; set; } = null!;

    public string? Комментарий { get; set; }

    public virtual Контрагенты КодКонтрагентаNavigation { get; set; } = null!;

    public virtual Пользователи КодПользователяNavigation { get; set; } = null!;

    public virtual ICollection<СоставОтгрузки> СоставОтгрузкиs { get; set; } = new List<СоставОтгрузки>();
}
