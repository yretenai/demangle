// Copyright 2020 Yretenai
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// https://github.com/yretenai/demangle/blob/develop/LICENSE
//
// SPDX-License-Identifier: Apache-2.0 WITH LLVM-exception

#ifndef DEMANGLE_DEMANGLE_H
#define DEMANGLE_DEMANGLE_H

#ifdef WIN32
    #ifndef DEMANGLE_IMPORT
        #define DEMANGLE_EXPORT_MODE dllexport
    #else // DEMANGLE_IMPORT
        #define DEMANGLE_EXPORT_MODE dllimport
    #endif // DEMANGLE_IMPORT
#endif // WIN32

#ifndef DEMANGLE_EXPORT
    #ifdef WIN32
    #define DEMANGLE_EXPORT __declspec(DEMANGLE_EXPORT_MODE)
    #else // WIN32
    #define DEMANGLE_EXPORT __attribute__((visibility("default")))
    #endif // WIN32
#endif // DEMANGLE_EXPORT

#ifdef __cplusplus
extern "C" {
#endif // __cplusplus
    enum demangle_status : int {
        demangle_unknown_error = -4,
        demangle_invalid_args = -3,
        demangle_invalid_mangled_name = -2,
        demangle_memory_alloc_failure = -1,
        demangle_success = 0,
    };

    enum MSDemangleFlags {
        MSDF_None = 0,
        MSDF_DumpBackrefs = 1 << 0,
        MSDF_NoAccessSpecifier = 1 << 1,
        MSDF_NoCallingConvention = 1 << 2,
        MSDF_NoReturnType = 1 << 3,
        MSDF_NoMemberType = 1 << 4,
    };

    DEMANGLE_EXPORT bool is_itanium_encoding(const char *mangled_name);
    DEMANGLE_EXPORT char *demangle(const char *mangled_name, demangle_status *status);
    DEMANGLE_EXPORT char *itanium_demangle(const char *mangled_name, demangle_status *status);
    DEMANGLE_EXPORT char *
    microsoft_demangle(const char *mangled_name, demangle_status *status, MSDemangleFlags flags = MSDF_None);

#ifdef __cplusplus
}
#endif // __cplusplus

#endif //DEMANGLE_DEMANGLE_H
