using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace UnmanagedDelegateExamples.Native {
    public enum UserMessage {
        Startup,
        Shutdown,
        DequeueDelegate
    }

    public class WindowProcHook {
        // // WM_USER can be defined as anything between 0x0400 and 0x7FFF
        private const int WM_USER = 0x0400;
        private const int GWL_WNDPROC = -4;
        private readonly ConcurrentQueue<InvokeDelegateTarget> _delegateTargets;
        private readonly int _mainThreadId;
        private WindowProcCallBack _newCallback;
        private IntPtr _oldCallback;

        public WindowProcHook(IntPtr handle) {
            Handle = handle;
            _delegateTargets = new ConcurrentQueue<InvokeDelegateTarget>();
            _mainThreadId = Process.GetCurrentProcess().Threads[0].Id;
        }

        public IntPtr Handle { get; }

        public bool IsDisposed { get; private set; }

        public bool IsEnabled { get; private set; }

        public bool MustBeDisposed { get; set; } = true;

        public Action OnStartUp { get; set; }

        public Action OnShutDown { get; set; }

        public bool InvokeRequired => Kernel32.GetCurrentThreadId() != _mainThreadId;

        public void Invoke(UserMessage msg) => User32.SendMessage(Handle, WM_USER, (IntPtr) msg, IntPtr.Zero);

        public object Invoke<T>(T target, params object[] args) where T : class {
            var targetDelegate = target as Delegate;
            if (targetDelegate == null) {
                throw new ArgumentException("Target method is not a delegate type.");
            }

            if (!InvokeRequired) {
                return targetDelegate.DynamicInvoke(args);
            }

            var callback = new InvokeDelegateTarget(targetDelegate, args);

            _delegateTargets.Enqueue(callback);

            Invoke(UserMessage.DequeueDelegate);

            var stopwatch = Stopwatch.StartNew();

            while (!callback.Completed) {
                if (stopwatch.ElapsedMilliseconds < 2000) {
                    continue;
                }
                stopwatch.Stop();
                throw new TimeoutException(
                    $"Could not invoke {targetDelegate.Method} from main thread (timed out after two seconds.)");
            }

            stopwatch.Stop();
            return callback.Result;
        }

        public void Enable() {
            _newCallback = OnWndProc;

            _oldCallback = User32.SetWindowLongPtr(Handle, GWL_WNDPROC,
                Marshal.GetFunctionPointerForDelegate(_newCallback));

            if (_oldCallback == IntPtr.Zero) {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            IsEnabled = true;
        }

        public void Disable() {
            if (_newCallback == null) {
                return;
            }

            User32.SetWindowLongPtr(Handle, GWL_WNDPROC, _oldCallback);
            _newCallback = null;
            IsEnabled = false;
        }

        public void Dispose() {
            if (IsDisposed) {
                return;
            }

            IsDisposed = true;

            if (IsEnabled) {
                Disable();
            }

            GC.SuppressFinalize(this);
        }

        private IntPtr OnWndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam) {
            if (msg == WM_USER && HandleUserMessage((UserMessage) wParam)) {
                return IntPtr.Zero;
            }
            return User32.CallWindowProc(_oldCallback, hWnd, msg, wParam, lParam);
        }

        private bool HandleUserMessage(UserMessage message) {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (message) {
                case UserMessage.Startup:
                    return true;
                case UserMessage.Shutdown:
                    return true;
                case UserMessage.DequeueDelegate:
                    DequeueDelegate();
                    return true;
            }
            return false;
        }

        ~WindowProcHook() {
            if (MustBeDisposed) {
                Dispose();
            }
        }

        private void DequeueDelegate() {
            InvokeDelegateTarget callback;
            while (_delegateTargets.TryDequeue(out callback)) {
                callback.Result = callback.Target.DynamicInvoke(callback.Args);
                callback.Completed = true;
            }
        }

        private class InvokeDelegateTarget {
            public InvokeDelegateTarget(Delegate target, params object[] args) {
                Target = target;
                Args = args;
            }

            public object[] Args { get; }
            public bool Completed { get; set; }
            public object Result { get; set; }
            public Delegate Target { get; }
        }
    }
}