using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.Entities;

namespace Domain.Interfaces
{
    public interface IPedido : IGeneric<Pedido>
    {
        Task<IEnumerable<object>> Query9Requerid();
    }
}