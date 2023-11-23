using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Persistence.Entities;

public partial class GamaProducto : BaseEntity
{
    public int Id { get; set; }

    public string? DescripcionTexto { get; set; }

    public string? DescripcionHtml { get; set; }

    public string? Imagen { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
