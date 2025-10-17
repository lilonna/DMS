using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DMS.Models;

public partial class DesktopName
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [InverseProperty("DesktopName")]
    public virtual ICollection<Desktop> Desktops { get; set; } = new List<Desktop>();
}
