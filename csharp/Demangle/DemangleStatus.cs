namespace Demangle
{
    public enum DemangleStatus
    {
        UnknownError = -4,
        InvalidArgs = -3,
        InvalidMangledName = -2,
        MemoryAllocFailure = -1,
        Success = 0
    }
}
