﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MyBridgeHRMS.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string GuardName { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public ulong? ParentId { get; set; }

    public ICollection<Employees> Employees { get; set; } = new List<Employees>();

    //public virtual ICollection<ModelHasRole> ModelHasRoles { get; set; } = new List<ModelHasRole>();

    //public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}