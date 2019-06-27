using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class User
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Device> Devices { get; set; }
    }
}
