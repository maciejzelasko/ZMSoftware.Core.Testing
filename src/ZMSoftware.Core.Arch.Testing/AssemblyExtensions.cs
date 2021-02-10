using System.Reflection;
using JetBrains.Annotations;
using NetArchTest.Rules;

namespace ZMSoftware.Core.Arch.Testing
{
    [PublicAPI]
    public static class NetArchTestExtensions
    {
        /// <summary>
        /// Checks if one assembly doesn't depend on another assembly
        /// </summary>
        public static TestResult CheckIfNotDependsOn(this Assembly inAssembly, Assembly assemblyToCheck) =>
            Types.InAssembly(inAssembly)
                .Should()
                .NotHaveDependencyOn(assemblyToCheck.GetName().Name)
                .GetResult();
    }
}