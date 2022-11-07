using System.Runtime.InteropServices;

namespace lldb;

[StructLayout(LayoutKind.Explicit, Size = 8)]
[CppObject]
public unsafe partial struct SBCommandInterpreter
{
    public partial SBCommand AddCommand(byte* name, IntPtr impl, byte* help);
}