using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleClient
{
    public class ClientConfig
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TokenValidation TokenValidation {get;set;}
    }
}
