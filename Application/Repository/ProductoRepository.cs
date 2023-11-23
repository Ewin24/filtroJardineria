using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Repository;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Entities;

namespace Aplication.Repository
{
    public class ProductoRepository : GenericRepository<Producto>, IProducto
    {
        private readonly JardineriaContext _context;
        public ProductoRepository(JardineriaContext context) : base(context)
        {
            _context = context;
        }

        // 2. Devuelve el nombre del producto que tenga el precio de venta más caro.
        public async Task<object> Query2WithOperatorBasic()
        {
            var nombreProducto = await _context.Productos
                .Where(p => p.PrecioVenta == _context.Productos.Max(pr => pr.PrecioVenta))
                .Select(p => p.Nombre)
                .ToListAsync();

            return nombreProducto;
        }
    }
}