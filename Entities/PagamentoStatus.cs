using System;
using System.Collections.Generic;

namespace Pedfast.Entities;

public partial class PagamentoStatus
{
    public string Status { get; set; } = null!;

    public string StatuComp { get; set; } = null!;

    public int IdS { get; set; }

    public virtual ICollection<Pedido> PedidoStatusCompNavigations { get; set; } = new List<Pedido>();

    public virtual ICollection<Pedido> PedidoStatusSgNavigations { get; set; } = new List<Pedido>();
}
