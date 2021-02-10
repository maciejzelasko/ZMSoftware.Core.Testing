using FluentAssertions;
using Xunit;

namespace ZMSoftware.Core.Arch.Testing.Tests
{
    public class TypeExtensionsTests
    {
        [Fact]
        public void HasPrivateParameterlessConstructor_TypeHasPrivateParameterlessConstructor_ReturnsTrue() => 
            typeof(ClassWithPrivateParameterlessConstructor).HasPrivateParameterlessConstructor()
                // Assert
                .Should()
                .BeTrue();

        [Fact]
        public void HasPrivateParameterlessConstructor_TypeDoesNotHavePrivateParameterlessConstructor_ReturnsFalse() => 
            typeof(ClassWithoutPrivateParameterlessConstructor).HasPrivateParameterlessConstructor()
                // Assert
                .Should()
                .BeFalse();
        
        [Fact]
        public void IsImmutable_ClassIsImmutable_ReturnsTrue() => 
            typeof(ImmutableClass).IsImmutable()
                // Assert
                .Should()
                .BeTrue();
        
        [Fact]
        public void IsImmutable_ClassIsNotImmutable_ReturnsFalse() => 
            typeof(NotImmutableClass).IsImmutable()
                // Assert
                .Should()
                .BeFalse();

        private class ClassWithPrivateParameterlessConstructor
        {
            private ClassWithPrivateParameterlessConstructor()
            {
            }
        }
        
        private class ClassWithoutPrivateParameterlessConstructor
        {
        }

        private class ImmutableClass
        {
            public string Prop { get; }
        }
        
        private class NotImmutableClass
        {
            public string Prop { get; set; }
        }
    }
}