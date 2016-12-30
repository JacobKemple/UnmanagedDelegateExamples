using System;

namespace UnmanagedDelegateExamples.Native {
    public delegate IntPtr WindowProcCallBack(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
}