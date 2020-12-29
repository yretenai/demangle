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
