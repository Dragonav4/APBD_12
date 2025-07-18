﻿using System;
using System.Collections.Generic;

namespace APBD_s31722_12.Models;

public partial class Doctor
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;
}
