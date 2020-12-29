cmake_minimum_required(VERSION 3.17)
project(demangle)

set(CMAKE_CXX_STANDARD 14)

set(LLVM_SOURCE_DIR ${CMAKE_CURRENT_SOURCE_DIR}/../llvm-project/llvm)
add_definitions(-D_CRT_SECURE_NO_WARNINGS)

add_executable(demangle Demangle.cpp
        ${LLVM_SOURCE_DIR}/lib/Demangle/Demangle.cpp
        ${LLVM_SOURCE_DIR}/lib/Demangle/MicrosoftDemangle.cpp
        ${LLVM_SOURCE_DIR}/lib/Demangle/MicrosoftDemangleNodes.cpp
        ${LLVM_SOURCE_DIR}/lib/Demangle/ItaniumDemangle.cpp)
target_include_directories(demangle PUBLIC "${LLVM_SOURCE_DIR}/include")