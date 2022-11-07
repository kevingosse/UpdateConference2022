using lldb;
using System.Runtime.InteropServices;

namespace LldbExtension;


public class Plugin
{
    private static NativeObjects.SBCommandPluginInterface Command;

    [UnmanagedCallersOnly(EntryPoint = "_ZN4lldb16PluginInitializeENS_10SBDebuggerE")]
    public static unsafe bool PluginInitialize(SBDebugger* debugger)
    {
        var interpreter = debugger->GetCommandInterpreter();

        Command = NativeObjects.SBCommandPluginInterface.Wrap(new MyCommand());

        fixed (byte* name = "mycommand"u8)
        fixed (byte* help = "Hello from Update Conference"u8)
        {
            var command = interpreter.AddCommand(name, Command.Object, help);
        }

        return true;
    }
}