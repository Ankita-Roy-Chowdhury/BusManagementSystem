using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BusManagementSystem.Models;

[Keyless]
public partial class BusView
{
    [Column("BusID")]
    public int BusId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string BoardingPoint { get; set; } = null!;
}
