using System;
using System.Collections.Generic;

namespace Склад_товаров.Models;

public partial class Роли
{
    public int КодРоли { get; set; }

    public string НазваниеРоли { get; set; } = null!;

    public virtual ICollection<Пользователи> Пользователиs { get; set; } = new List<Пользователи>();
}
