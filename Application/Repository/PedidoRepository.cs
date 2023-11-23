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
    public class PedidoRepository : GenericRepository<Pedido>, IPedido
    {
        private readonly JardineriaContext _context;
        public PedidoRepository(JardineriaContext context) : base(context)
        {
            _context = context;
        }

        //9. Devuelve un listado con el código de pedido, código de cliente, fecha esperada y fecha de entrega de los pedidos que no han sido entregados a tiempo.
        public async Task<IEnumerable<object>> Query9Requerid()
        {
            var result = from p in _context.Pedidos
                         where p.FechaEntrega > p.FechaEsperada
                         select new { p.Id, p.CodigoCliente, p.FechaEsperada, p.FechaEntrega };
            return await result.ToListAsync();
        }
    }
}