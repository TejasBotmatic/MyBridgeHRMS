﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MyBridgeHRMS.Models;

public partial class Termination
{
    public ulong Id { get; set; }

    public int EmployeeId { get; set; }

    public DateOnly NoticeDate { get; set; }

    public DateOnly TerminationDate { get; set; }

    public string TerminationType { get; set; }

    public string Description { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}