using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace ZMSoftware.Core.Arch.Testing
{
    [PublicAPI]
    public static class TypeExtensions
    {
        /// <summary>
        /// Checks if type has a private parameterless constructor
        /// </summary>
        public static bool HasPrivateParameterlessConstructor(this Type type) => 
            type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)
                .Any(constructorInfo => constructorInfo.IsPrivate && constructorInfo.GetParameters().Length == 0);

        /// <summary>
        /// Checks if the type is immutable (all properties are readonly)
        /// </summary>
        public static bool IsImmutable(this Type type) =>
            type.GetFields()
                .All(x => x.IsInitOnly) && type.GetProperties().All(x => x.CanWrite == false);
    }
}