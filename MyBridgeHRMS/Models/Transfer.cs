﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MyBridgeHRMS.Models;

public partial class Transfer
{
    public ulong Id { get; set; }

    public int EmployeeId { get; set; }

    public int BranchId { get; set; }

    public int DepartmentId { get; set; }

    public DateOnly TransferDate { get; set; }

    public string Description { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}