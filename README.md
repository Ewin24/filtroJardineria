Edwin Trigos Guevara

Enunciado de la consulta
EndPoint de la Consulta
Codigo de la consulta
Explicacion de la consulta

## Enunciado de la consulta
    //9. Devuelve un listado con el código de pedido, código de cliente, fecha esperada y fecha de entrega de los pedidos que no han sido entregados a tiempo.
## endpoint consulta: 

    controller/Query9Requerid

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