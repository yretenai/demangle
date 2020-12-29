using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Demangle
{
    public static class Demangler
    {
        private static string RuntimePath =
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, "runtimes");

        static Demangler()
        {
            NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), OnDllImport);
        }

        private static IntPtr OnDllImport(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            if (libraryName != "libdemangle") return IntPtr.Zero;
            var rid = RuntimeInformation.RuntimeIdentifier;
            return NativeLibrary.Load(Path.Combine(RuntimePath, rid, "native", libraryName));
        }

        public static bool IsItaniumEncoding(string mangledName)
        {
            var ptr = Marshal.StringToHGlobalAnsi(mangledName);
            try
            {
                return Native.IsItaniumEncoding(ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        public static string? Demangle(string mangledName)
        {
            return Demangle(mangledName, out _);
        }

        public static string? Demangle(string mangledName, out DemangleStatus status)
        {
            status = DemangleStatus.UnknownError;
            var ptr = Marshal.StringToHGlobalAnsi(mangledName);
            var demangledPtr = IntPtr.Zero;
            try
            {
                demangledPtr = Native.Demangle(ptr, ref status);
                return demangledPtr == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(demangledPtr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
                if (demangledPtr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(demangledPtr);
                }
            }
        }

        public static string? MicrosoftDemangle(string mangledName, MSDemangleFlags flags = MSDemangleFlags.None)
        {
            return MicrosoftDemangle(mangledName, out _, flags);
        }

        public static string? MicrosoftDemangle(string mangledName, out DemangleStatus status,
            MSDemangleFlags flags = MSDemangleFlags.None)
        {
            status = DemangleStatus.UnknownError;
            var ptr = Marshal.StringToHGlobalAnsi(mangledName);
            var demangledPtr = IntPtr.Zero;
            try
            {
                demangledPtr = Native.MicrosoftDemangle(ptr, ref status, flags);
                return demangledPtr == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(demangledPtr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
                if (demangledPtr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(demangledPtr);
                }
            }
        }

        public static string? ItaniumDemangle(string mangledName)
        {
            return ItaniumDemangle(mangledName, out _);
        }

        public static string? ItaniumDemangle(string mangledName, out DemangleStatus status)
        {
            status = DemangleStatus.UnknownError;
            var ptr = Marshal.StringToHGlobalAnsi(mangledName);
            var demangledPtr = IntPtr.Zero;
            try
            {
                demangledPtr = Native.ItaniumDemangle(ptr, ref status);
                return demangledPtr == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(demangledPtr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
                if (demangledPtr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(demangledPtr);
                }
            }
        }
    }
}
