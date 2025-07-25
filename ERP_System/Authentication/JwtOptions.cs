﻿using System.ComponentModel.DataAnnotations;

namespace ERP_System.Authentication
{
    public class JwtOptions
    {
        public static string SectionName = "Jwt";

        [Required]
        public string key { get; init; } = string.Empty;

        [Required]
        public string Issuer { get; init; } = string.Empty;

        [Required]
        public string Audience { get; init; } = string.Empty;

        [Range(1, int.MaxValue , ErrorMessage = "Invalid Expiry Minutes")]
        public int ExpiryMinutes { get; init; } 

    }
}
