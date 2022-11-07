using LldbExtension;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace lldb;

[CppObject]
public unsafe partial struct SBDebugger
{
    public partial lldb.SBCommandInterpreter GetCommandInterpreter();
}