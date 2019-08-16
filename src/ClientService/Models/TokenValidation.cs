
using System;

namespace ClientService.Models
{
    public class TokenValidation
    {
        public string? token {get;set;}
        public DateTime? expiration {get;set;}
    }
}