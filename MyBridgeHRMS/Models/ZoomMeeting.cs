﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MyBridgeHRMS.Models;

public partial class ZoomMeeting
{
    public ulong Id { get; set; }

    public string Title { get; set; }

    public string MeetingId { get; set; }

    public string UserId { get; set; }

    public string Password { get; set; }

    public DateTime StartDate { get; set; }

    public int Duration { get; set; }

    public string StartUrl { get; set; }

    public string JoinUrl { get; set; }

    public string Status { get; set; }

    public int CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}