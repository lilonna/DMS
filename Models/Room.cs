using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DMS.Models;

public partial class Room
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("Room")]
    public virtual ICollection<Desktop> Desktops { get; set; } = new List<Desktop>();
}
