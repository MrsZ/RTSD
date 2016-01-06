using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LinphoneCoreWrapper
{
    public class CoreWrapper
    {
        private const string LIBRARY_NAME = "Linphone.dll";

        [DllImport(LIBRARY_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern void linphone_core_destruction();
    }
}
