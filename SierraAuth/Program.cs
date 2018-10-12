using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SierraAuth
{
    class Program
    {
        [DllImport("GobiApi.dll")]
        public static extern uint SwiSetFccAuth();
        [DllImport("GobiApi.dll")]
        public static extern uint SwiGetFccAuth(out ulong pState);

        [DllImport("GobiApi.dll")]
        public static extern uint QCWWANGetConnectedDeviceID(ulong deviceNodeSize, out char pDeviceNode, ulong deviceKeySize, out char pDeviceKey);
        [DllImport("GobiApi.dll")]
        public static extern uint QCWWANConnect();

        static void Main(string[] args)
        {
            QCWWANConnect();
            //QCWWANGetConnectedDeviceID(10, out char pDeviceNode, 10, out char pDeviceKey);

            uint r4 = SwiSetFccAuth();
            if (r4 != 0 && r4 != 1026)
            {
                Console.WriteLine("Failed to set FCC auth! Error code: " + r4);
                Console.ReadLine();
                return;
            }
            
            Console.WriteLine("Successfully set FCC auth.");
        }
    }
}
