﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MyBridgeHRMS.Models;

public partial class Contract
{
    public ulong Id { get; set; }

    public string Subject { get; set; }

    public int EmployeeName { get; set; }

    public double? Value { get; set; }

    public int Type { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string Notes { get; set; }

    public string Status { get; set; }

    public string Description { get; set; }

    public string ContractDescription { get; set; }

    public string EmployeeSignature { get; set; }

    public string CompanySignature { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}