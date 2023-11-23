﻿using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Persistence.Entities;

public partial class DetallePedido : BaseEntity
{
    public int Id { get; set; }

    public string CodigoProducto { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal PrecioUnidad { get; set; }

    public short NumeroLinea { get; set; }

    public virtual Pedido CodigoPedidoNavigation { get; set; } = null!;

    public virtual Producto CodigoProductoNavigation { get; set; } = null!;
}
