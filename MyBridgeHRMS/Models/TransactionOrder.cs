﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MyBridgeHRMS.Models;

public partial class TransactionOrder
{
    public ulong Id { get; set; }

    public decimal ReqAmount { get; set; }

    public int ReqUserId { get; set; }

    public int Status { get; set; }

    public DateOnly? Date { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}