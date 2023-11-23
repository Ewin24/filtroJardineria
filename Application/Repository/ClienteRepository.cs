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
    public class ClienteRepository : GenericRepository<Cliente>, ICliente
    {
        private readonly JardineriaContext _context;
        public ClienteRepository(JardineriaContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<object>> Query4MultiInt()
        {
            var result = from c in _context.Clientes
                         join p in _context.Pagos on c.Id equals p.Id
                         join e in _context.Empleados on c.CodigoEmpleadoRepVentas equals e.Id
                         join o in _context.Oficinas on e.Id equals o.Id
                         select new { c.NombreCliente, e.Nombre, e.Apellido1, e.Apellido2, o.Ciudad };
            return await result.ToListAsync();
        }
        public async Task<List<object>> Query1Variate1()
        {
            var query1 = await _context.Clientes
                .GroupJoin(_context.Pedidos, c => c.Id, p => p.CodigoCliente, (cliente, pedidos) => new
                {
                    cliente.NombreCliente,
                    CantidadPedidos = pedidos.Count()
                })
                .ToListAsync<object>();

            return query1;
        }
    }
}