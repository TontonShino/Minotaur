using System;
using Ipify;

namespace ClientService
{
    public class DeviceInfo
    {
         public static string GetMachineName()
        {
            return Environment.MachineName;
        }
        public static string GetMachineIPAddrress()
        {
            return IpifyIp.GetPublicIp();
        }
        public static string GetMachineDescription()
        {
            return $"Os Version:{Environment.OSVersion} - Version :{Environment.Version} - Processor count:{Environment.ProcessorCount}";
        }
        
    }
}