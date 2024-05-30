using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TableStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TableInfo> TableInfos { get; set; } = new List<TableInfo>();
}
