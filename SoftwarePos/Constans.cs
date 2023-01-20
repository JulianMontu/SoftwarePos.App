using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwarePos
{
    public static class Constans
    {
        public static string RestUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5288/api/" : "http://localhost:5288/api/";
    }
}
