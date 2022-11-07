using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Profiler;

public unsafe class ClassFactory : IClassFactory
{
    public NativeObjects.IClassFactory Object { get; private set; }

    public ClassFactory()
    {
        Object = NativeObjects.IClassFactory.Wrap(this);
    }


    public int QueryInterface(in Guid guid, out IntPtr ptr)
    {
        Console.WriteLine("QueryInterface");
        ptr = IntPtr.Zero;
        return 0;
    }

    public int AddRef()
    {
        Console.WriteLine("AddRef");
        return 1;
    }

    public int Release()
    {
        Console.WriteLine("Release");
        return 1;
    }

    public int CreateInstance(IntPtr outer, in Guid guid, out IntPtr instance)
    {
        Console.WriteLine("CreateInstance");

        Callback = new CorProfilerCallback();

        instance = Callback.Object;

        return 0;

    }

    private CorProfilerCallback Callback { get; set; }

    public int LockServer(bool @lock)
    {
        Console.WriteLine("LockServer");
        return 0;
    }
}

public class DllMain
{
    private static ClassFactory _factory;

    [UnmanagedCallersOnly(EntryPoint = "DllGetClassObject")]
    public static unsafe int DllGetClassObject(Guid* rclsid, Guid* riid, IntPtr* ppv)
    {
        Console.WriteLine("DllGetClassObject");

        _factory = new ClassFactory();

        *ppv = _factory.Object;

        return 0;
    }
}