// Copyright 2020 Yretenai
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// https://github.com/yretenai/demangle/blob/develop/LICENSE
//
// SPDX-License-Identifier: Apache-2.0 WITH LLVM-exception

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
