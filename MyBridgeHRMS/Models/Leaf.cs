﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MyBridgeHRMS.Models;

public partial class Leaf
{
    public ulong Id { get; set; }

    public int EmployeeId { get; set; }

    public int LeaveTypeId { get; set; }

    public DateOnly AppliedOn { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string TotalLeaveDays { get; set; }

    public string LeaveReason { get; set; }

    public string Remark { get; set; }

    public string Status { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string LeaveType { get; set; }

    public string SalaryTypeLeave { get; set; }

    public string AvailbleLeave { get; set; }

    public string UsedLeave { get; set; }

    public string AllocatedLeave { get; set; }
}