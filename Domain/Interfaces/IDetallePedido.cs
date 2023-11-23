using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence.Entities;

namespace Domain.Interfaces
{
    public interface IDetallePedido : IGeneric<DetallePedido>
    {
        // 14. Devuelve un listado de los 20 productos más vendidos y el número total de unidades que se han vendido de cada uno. El listado deberá estar ordenado por el número total de unidades vendidas.
        Task<IEnumerable<object>> Query14Summary();
        // 18. Lista las ventas totales de los productos que hayan facturado más de 3000 euros. Se mostrará el nombre, unidades vendidas, total facturado y total facturado con impuestos (21% IVA).

        Task<IEnumerable<object>> Query18Summary();


    }
}