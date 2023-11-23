Edwin Trigos Guevara

Enunciado de la consulta
EndPoint de la Consulta
Codigo de la consulta
Explicacion de la consulta

## Enunciado de la consulta
    //9. Devuelve un listado con el código de pedido, código de cliente, fecha esperada y fecha de entrega de los pedidos que no han sido entregados a tiempo.
## endpoint consulta: 

    pedido/Query9Requerid

## codigo:
```
    public async Task<IEnumerable<object>> Query9Requerid()
    {
        var result = from p in _context.Pedidos
                        where p.FechaEntrega > p.FechaEsperada
                        select new { p.Id, p.CodigoCliente, p.FechaEsperada, p.FechaEntrega };
        return await result.ToListAsync();
    }
```



// 10. Devuelve las oficinas donde no trabajan ninguno de los empleados que hayan sido los representantes de ventas de algún cliente que haya realizado la compra de algún producto de la gama Frutales.
## endpoint consulta: 
oficina/Query10MultiEx
```

public async Task<IEnumerable<object>> Query10MultiEx()
{
        var result = from o in context.Oficina
                    where !(
                        from ofi in context.Oficina
                        join e in context.Empleado on ofi.codigo_oficina equals e.codigo_oficina
                        join c in context.Cliente on e.codigo_empleado equals c.codigo_empleado_rep_ventas
                        join pe in context.Pedido on c.codigo_cliente equals pe.codigo_cliente
                        join dp in context.DetallePedido on pe.codigo_pedido equals dp.codigo_pedido
                        join pr in context.Producto on dp.codigo_producto equals pr.codigo_producto
                        where pr.gama == "Frutales"
                        select ofi.codigo_oficina
                    ).Contains(o.codigo_oficina)
                    select o;
        return await result.ToListAsync();
    }
```



    // 5. Devuelve el nombre de los clientes que no hayan hecho pagos y el nombre de sus representantes junto con la ciudad de la oficina a la que pertenece el representante.
## endpoint consulta: 
cliente/Query4MultiInt
```

public async Task<IEnumerable<object>> Query4MultiInt()
        {
            var result = from c in _context.Clientes
                         join p in _context.Pagos on c.Id equals p.Id
                         join e in _context.Empleados on c.CodigoEmpleadoRepVentas equals e.Id
                         join o in _context.Oficinas on e.Id equals o.Id
                         select new { c.NombreCliente, e.Nombre, e.Apellido1, e.Apellido2, o.Ciudad };
            return await result.ToListAsync();
        }
```


// 14. Devuelve un listado de los 20 productos más vendidos y el número total de unidades que se han vendido de cada uno. El listado deberá estar ordenado por el número total de unidades vendidas.
## endpoint consulta: 
detallePedido/Query14Summary

```
public async Task<IEnumerable<object>> Query14Summary()
        {
            var result = (from dp in _context.DetallePedidos
                          group dp by dp.Id into g
                          orderby g.Sum(dp => dp.Cantidad) descending
                          select new { CodigoProducto = g.Key, UnidadesVendidas = g.Sum(dp => dp.Cantidad) }).Take(20);
            return await result.ToListAsync();
        }
```


// 18. Lista las ventas totales de los productos que hayan facturado más de 3000 euros. Se mostrará el nombre, unidades vendidas, total facturado y total facturado con impuestos (21% IVA).
## endpoint consulta: 
detallePedido/Query18Summary

```
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
```

// 2. Devuelve el nombre del producto que tenga el precio de venta más caro.
## endpoint consulta: 
productos/Query2WithOperatorBasic

```
public async Task<object> Query2WithOperatorBasic()
        {
            var nombreProducto = await _context.Productos
                .Where(p => p.PrecioVenta == _context.Productos.Max(pr => pr.PrecioVenta))
                .Select(p => p.Nombre)
                .ToListAsync();

            return nombreProducto;
        }
```
