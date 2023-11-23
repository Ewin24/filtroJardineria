using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.Entities;

namespace Domain.Interfaces
{
    public interface IProducto : IGeneric<Producto>
    {
        // 2. Devuelve el nombre del producto que tenga el precio de venta más caro.
        Task<object> Query2WithOperatorBasic();
    }
}