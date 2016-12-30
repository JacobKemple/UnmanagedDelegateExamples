# UnmanagedDelegateExamples
Example for Kristin Xie

Notes

1. For this example to work, the application must be loaded into the process module that contains the unmanaged functions.

2. This means that the best way to test is to create a C++ program with the same unmanaged function signatures here,
   and inject and host your app and the CLR. I suggest doing that by using my DomainWrapper here:
   https://github.com/lolp1/DomainWrapper and calling the export with the path to the test app here.
   
3. /src/UnmanagedDelegateExamples/Native/WindowProcHook.cs contains the code to invoke the unmanaged delegates.

4. /src/UnmanagedDelegateExamples/Engine.cs contains the unmanaged delegates. You can use any equivelent C++ signature in - 
   the test C++ app you inject into. 
