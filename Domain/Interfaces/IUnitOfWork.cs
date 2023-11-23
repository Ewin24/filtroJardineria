
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    ICliente Cliente { get; }
    IEmpleado Empleado { get; }
    IOficina Oficina { get; }
    IPago Pago { get; }
    IProducto Producto { get; }
    IPedido Pedido { get; }
    IDetallePedido DetallePedido { get; }
    Task<int> SaveAsync();
}