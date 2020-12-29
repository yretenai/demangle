// Copyright 2020 Yretenai
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// https://github.com/yretenai/demangle/blob/develop/LICENSE
//
// SPDX-License-Identifier: Apache-2.0 WITH LLVM-exception

#include "Demangle.h"

#include <cstring>

#include <llvm/Demangle/Demangle.h>

bool is_itanium_encoding(const char *mangled_name) {
    size_t pos = std::string(mangled_name).find_first_not_of('_');
    return pos > 0 && pos <= 4 && mangled_name[pos] == 'Z';
}

char *demangle(const char *mangled_name, demangle_status *status) {
    if(is_itanium_encoding(mangled_name)) {
        return itanium_demangle(mangled_name, status);
    } else {
        return microsoft_demangle(mangled_name, status, MSDF_None);
    }
}

char *itanium_demangle(const char *mangled_name, demangle_status *status) {
    return llvm::itaniumDemangle(mangled_name, nullptr, nullptr, reinterpret_cast<int *>(status));
}

char * microsoft_demangle(const char *mangled_name, demangle_status *status, MSDemangleFlags flags) {
    return llvm::microsoftDemangle(mangled_name, nullptr, nullptr, nullptr, reinterpret_cast<int *>(status),
                                   static_cast<llvm::MSDemangleFlags>(flags));
}