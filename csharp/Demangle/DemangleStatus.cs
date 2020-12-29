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
    public enum DemangleStatus
    {
        UnknownError = -4,
        InvalidArgs = -3,
        InvalidMangledName = -2,
        MemoryAllocFailure = -1,
        Success = 0
    };
}
