using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DMS.Models;

public partial class Desktop
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column("Serial Number")]
    [StringLength(50)]
    public string SerialNumber { get; set; } = null!;

    public int? UserId { get; set; }

    [Column("Issue Report")]
    public string? IssueReport { get; set; }

    public int RoomId { get; set; }

    [ForeignKey("RoomId")]
    [InverseProperty("Desktops")]
    public virtual Room Room { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Desktops")]
    public virtual User? User { get; set; }
}
