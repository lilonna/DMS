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

    public int? DesktopNameId { get; set; }

    [StringLength(100)]
    public string SerialNumber { get; set; } = null!;

    public int? UserId { get; set; }

    public string? IssueReport { get; set; }

    public int? RoomId { get; set; }

    [ForeignKey("DesktopNameId")]
    [InverseProperty("Desktops")]
    public virtual DesktopName? DesktopName { get; set; }

    [ForeignKey("RoomId")]
    [InverseProperty("Desktops")]
    public virtual Room? Room { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Desktops")]
    public virtual User? User { get; set; }
}
