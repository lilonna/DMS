using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DMS.Models;

[Keyless]
public partial class User
{
    public int Id { get; set; }

    [Column("First Name")]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Column("Middle Name")]
    [StringLength(50)]
    public string MiddleName { get; set; } = null!;

    [Column("Last Name")]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    public int GenderId { get; set; }

    [Column("Phone Number")]
    [StringLength(50)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(50)]
    public string Position { get; set; } = null!;
}
