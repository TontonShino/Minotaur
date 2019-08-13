using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib
{
    public class AppUserToken
    {
        public string Id { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime CreationDate { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }

    }
}
