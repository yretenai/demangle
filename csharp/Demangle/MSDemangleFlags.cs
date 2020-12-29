// Copyright 2020 Yretenai
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// https://github.com/yretenai/demangle/blob/develop/LICENSE
//
// SPDX-License-Identifier: Apache-2.0 WITH LLVM-exception

namespace Demangle
{
    public enum MSDemangleFlags
    {
        None = 0,
        DumpBackrefs = 1 << 0,
        NoAccessSpecifier = 1 << 1,
        NoCallingConvention = 1 << 2,
        NoReturnType = 1 << 3,
        NoMemberType = 1 << 4
    };
}
