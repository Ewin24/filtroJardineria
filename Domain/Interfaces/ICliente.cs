using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.Entities;

namespace Domain.Interfaces
{
    public interface ICliente : IGeneric<Cliente>
    {
        Task<IEnumerable<object>> Query4MultiInt();
        // 1. Devuelve el listado de clientes indicando el nombre del cliente y cuántos pedidos ha realizado 
        
        Task<List<object>> Query1Variate1();
    }
}