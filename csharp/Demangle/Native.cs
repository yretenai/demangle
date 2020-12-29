using System;
using System.Runtime.InteropServices;

namespace Demangle
{
    internal static class Native
    {
        [DllImport("libdemangle", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi,
            EntryPoint = "demangle", ExactSpelling = true)]
        internal static extern IntPtr Demangle([In] IntPtr mangledName,
            [MarshalAs(UnmanagedType.I4)] [In] [Out]
            ref DemangleStatus status);

        [DllImport("libdemangle", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi,
            EntryPoint = "itanium_demangle", ExactSpelling = true)]
        internal static extern IntPtr ItaniumDemangle([In] IntPtr mangledName,
            [MarshalAs(UnmanagedType.I4)] [In] [Out]
            ref DemangleStatus status);

        [DllImport("libdemangle", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi,
            EntryPoint = "microsoft_demangle", ExactSpelling = true)]
        internal static extern IntPtr MicrosoftDemangle([MarshalAs(UnmanagedType.LPStr)] [In] IntPtr mangledName,
            [MarshalAs(UnmanagedType.I4)] [In] [Out]
            ref DemangleStatus status,
            [MarshalAs(UnmanagedType.I4)] [In] MSDemangleFlags flags = MSDemangleFlags.None);

        [DllImport("libdemangle", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi,
            EntryPoint = "is_itanium_encoding", ExactSpelling = true)]
        internal static extern bool IsItaniumEncoding([In] IntPtr mangledName);
    }
}
