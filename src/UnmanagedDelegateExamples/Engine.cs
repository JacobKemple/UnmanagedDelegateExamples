using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using UnmanagedDelegateExamples.Native;

namespace UnmanagedDelegateExamples {
    public static class Engine {
        private static TryGetLocationA _tryGetLocationA;
        private static TryGetLocationB _tryGetLocationB;
        private static IsEntityValidA _isEntityValidA;
        private static IsEntityValidB _isEntityValidB;
        private static bool _isInitialzed;
        private static WindowProcHook _window;

        public static void Initialize(IntPtr handle, IntPtr funcPtrGetLocation, IntPtr funcPtrIsEntityValid) {
            if (_isInitialzed) {
                return;
            }

            _tryGetLocationA =
                Marshal.GetDelegateForFunctionPointer(funcPtrGetLocation, typeof(TryGetLocationA)) as TryGetLocationA;
            _tryGetLocationB =
                Marshal.GetDelegateForFunctionPointer(funcPtrGetLocation, typeof(TryGetLocationB)) as TryGetLocationB;

            _isEntityValidA =
                Marshal.GetDelegateForFunctionPointer(funcPtrIsEntityValid, typeof(IsEntityValidA)) as IsEntityValidA;
            _isEntityValidB =
                Marshal.GetDelegateForFunctionPointer(funcPtrIsEntityValid, typeof(IsEntityValidB)) as IsEntityValidB;

            _window = new WindowProcHook(handle) {
                OnStartUp = OnStartUp,
                OnShutDown = OnShutDown
            };

            _isInitialzed = true;
        }

        public static void Apply() {
            _window.Enable();
            _window.Invoke(UserMessage.Startup);
        }

        public static void Remove() {
            _window.Invoke(UserMessage.Shutdown);
            _window.Disable();
        }

        // This way works as expected with no limits.
        // delegate void TryGetLocationA(IntPtr address, out Vector3 result);	
        public static Vector3 GetLocationA(IntPtr address) {
            Vector3 location;
            // note: Invoke(_tryGetLocationA, address, out location) is not possible here.
            _tryGetLocationA(address, out location);
            return location;
        }

        // In this example, we use a trick to be able to 
        // use the out despite using params object[] args
        // not allowing you to pass out or ref.
        // delegate void TryGetLocationB(IntPtr address, [Out] Vector3[] result);	
        public static Vector3 GetLocationB(IntPtr address) {
            // note: if your delegate signature - 
            // has out and not the attribute [Out]
            // it will fail.
            var location = new Vector3[1];
            // The result gets passed to the first index of the array, 0.
            // Use our special invoke method with params object[] thus not allowing - 
            // us to use out directly like in example A.
            _window.Invoke(_tryGetLocationB, address, location);
            return location[0];
        }

        // This way works fine and as expected.
        public static bool IsEntityValid_A(IntPtr entityAddress) {
            // note:  (bool) Invoke(_isEntityValidA, ref entityAddress) is not valid here.
            return _isEntityValidA(ref entityAddress);
        }

        public static bool IsEntityValid_B(IntPtr entityAddress) {
            // note: no ref tag needed here, unlike the [Out] example.
            // The array trick allows us to once again by pass the limit -
            // of not being able to use ref in params object[] (or params of any kind).
            var isEntityValid = (bool) _window.Invoke(_isEntityValidB, new[] {entityAddress});
            return isEntityValid;
        }

        private static void OnStartUp() {
            MessageBox.Show("Start up");
        }

        private static void OnShutDown() {
            MessageBox.Show("Shutting down");
        }

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void TryGetLocationB(IntPtr address, [Out] Vector3[] result);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate void TryGetLocationA(IntPtr address, out Vector3 result);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool IsEntityValidA(ref IntPtr entityAddress);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        private delegate bool IsEntityValidB(IntPtr[] entityAddress);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3 {
        public int X;
        public int Y;
        public int Z;
    }
}