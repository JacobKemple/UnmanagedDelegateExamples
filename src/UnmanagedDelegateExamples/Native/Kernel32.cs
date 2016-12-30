using System.Runtime.InteropServices;

namespace UnmanagedDelegateExamples {
    public static class Kernel32 {
        [DllImport("kernel32.dll")]
        public static extern int GetCurrentThreadId();
    }
}