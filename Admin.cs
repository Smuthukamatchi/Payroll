using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Routing.Matching;

namespace PayrollApp.Models
{
    public partial class Admin
    {
        public Int16 Id { get; set; } = default!;
        public string? Firstname { get; set; } = null!;
        public string? Lastname { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public string? Password { get; set; } = null!;
        
    }
}
