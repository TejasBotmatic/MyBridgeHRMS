﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MyBridgeHRMS.Models;

public partial class Complaint
{
    public ulong Id { get; set; }

    public int ComplaintFrom { get; set; }

    public int ComplaintAgainst { get; set; }

    public string Title { get; set; }

    public DateOnly ComplaintDate { get; set; }

    public string Description { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}