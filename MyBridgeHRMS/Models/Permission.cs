﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MyBridgeHRMS.Models;

public partial class Permission
{
    public ulong Id { get; set; }

    public string Name { get; set; }

    public string GuardName { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ModelHasPermission> ModelHasPermissions { get; set; } = new List<ModelHasPermission>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}