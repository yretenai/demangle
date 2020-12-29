// Copyright 2020 Yretenai
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// https://github.com/yretenai/demangle/blob/develop/LICENSE
//
// SPDX-License-Identifier: Apache-2.0 WITH LLVM-exception

#include <iostream>
#include <string>

#include <llvm/Demangle/Demangle.h>

using namespace std;

int main(int argc, char** argv) {
    if(argc <= 1) {
        cout << "USAGE: demangle _Zmangled_names..." << endl;
        return 1;
    }

    for(auto i = 1; i < argc; ++i) {
        std::string mangled_name = argv[i];
        cout << llvm::demangle(mangled_name) << endl;
    }

    return 0;
}