using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Склад_товаров.Models;

namespace Склад_товаров.Services
{
    public class ProductService
    {
        public async Task<List<Товары>> GetProductsAsync()
        {
            using (var db = new WarehouseDbContext())
            {
                return await db.Товарыs
                    .AsNoTracking()
                    .Where(product => product.Активен)
                    .OrderBy(product => product.Наименование)
                    .ToListAsync();
            }
        }
    }
}
