﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MyBridgeHRMS.Models;

public partial class SalaryDetail
{
    public ulong Id { get; set; }

    public ulong SalaryBandId { get; set; }

    public decimal BasicMonthly { get; set; }

    public decimal BasicAnnually { get; set; }

    public decimal HraMonthly { get; set; }

    public decimal HraAnnually { get; set; }

    public decimal StatutoryBonusMonthly { get; set; }

    public decimal StatutoryBonusAnnually { get; set; }

    public decimal SpecialAllowanceMonthly { get; set; }

    public decimal SpecialAllowanceAnnually { get; set; }

    public decimal ProvidentFundMonthly { get; set; }

    public decimal ProvidentFundAnnually { get; set; }

    public decimal TotalPayMonthly { get; set; }

    public decimal TotalPayAnnually { get; set; }

    public decimal TotalCtcMonthly { get; set; }

    public decimal TotalCtcAnnually { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}