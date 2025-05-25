using System;
using System.Collections.Generic;

namespace Pedfast.Entities;

public partial class PedidosBackup
{
    public int Id { get; set; }

    public string Cliente { get; set; } = null!;

    public DateOnly Data { get; set; }

    public string StatusSg { get; set; } = null!;

    public string StatusComp { get; set; } = null!;
}
