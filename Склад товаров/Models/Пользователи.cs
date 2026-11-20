using System;
using System.Collections.Generic;

namespace Склад_товаров.Models;

public partial class Пользователи
{
    public int КодПользователя { get; set; }

    public string Фио { get; set; } = null!;

    public string Логин { get; set; } = null!;

    public string ХешПароля { get; set; } = null!;

    public int КодРоли { get; set; }

    public bool Активен { get; set; }

    public DateTime ДатаСоздания { get; set; }

    public virtual Роли КодРолиNavigation { get; set; } = null!;

    public virtual ICollection<Отгрузки> Отгрузкиs { get; set; } = new List<Отгрузки>();

    public virtual ICollection<Поступления> Поступленияs { get; set; } = new List<Поступления>();
}
