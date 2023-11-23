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
    public class DetallePedidoRepository : GenericRepository<DetallePedido>, IDetallePedido
    {
        private readonly JardineriaContext _context;
        public DetallePedidoRepository(JardineriaContext context) : base(context)
        {
            _context = context;
        }
        // 14. Devuelve un listado de los 20 productos más vendidos y el número total de unidades que se han vendido de cada uno. El listado deberá estar ordenado por el número total de unidades vendidas.
        public async Task<IEnumerable<object>> Query14Summary()
        {
            var result = (from dp in _context.DetallePedidos
                          group dp by dp.Id into g
                          orderby g.Sum(dp => dp.Cantidad) descending
                          select new { CodigoProducto = g.Key, UnidadesVendidas = g.Sum(dp => dp.Cantidad) }).Take(20);
            return await result.ToListAsync();
        }
        // 18. Lista las ventas totales de los productos que hayan facturado más de 3000 euros. Se mostrará el nombre, unidades vendidas, total facturado y total facturado con impuestos (21% IVA).
        public async Task<IEnumerable<object>> Query18Summary()
        {
            var result = from dp in _context.DetallePedidos
                         group dp by dp.Id into g
                         let totalFacturado = g.Sum(dp => dp.PrecioUnidad * dp.Cantidad)
                         where totalFacturado > 3000
                         select new
                         {
                             CodigoProducto = g.Key,
                             UnidadesVendidas = g.Sum(dp => dp.Cantidad),
                             TotalFacturado = totalFacturado,
                             TotalFacturadoConImpuestos = Math.Round(totalFacturado * 1,21)
                         };
            return await result.ToListAsync();
        }
    }
}