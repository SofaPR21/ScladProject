using System;
using System.Collections.Generic;

namespace Склад_товаров.Models;

public partial class Контрагенты
{
    public int КодКонтрагента { get; set; }

    public string Наименование { get; set; } = null!;

    public string ТипКонтрагента { get; set; } = null!;

    public string? Телефон { get; set; }

    public string? ЭлектроннаяПочта { get; set; }

    public string? Адрес { get; set; }

    public virtual ICollection<Отгрузки> Отгрузкиs { get; set; } = new List<Отгрузки>();

    public virtual ICollection<Поступления> Поступленияs { get; set; } = new List<Поступления>();
}
