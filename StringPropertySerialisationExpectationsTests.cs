using System;
using FluentAssertions;
using Xunit;

namespace NullableSerialisationExperiments
{
    public abstract class StringPropertySerialisationExpectationsTests<T>
    where T : StringPropertySerialisationExpectationsTests<T>.Interface
    {
        public interface Interface
        {
            string Value { get; }
        }

        public abstract T Deserialise(string json);

        [Fact]
        public void HavingAValueDeserialises()
        {
            var json = "{ \"value\": \"A Value\" }";
            var result = Deserialise(json);
            result.Value.Should().Be("A Value");
        }

        [Fact]
        public void HavingANullValueThrowsException()
        {
            var json = "{ \"value\": null }";
            Action action = () => Deserialise(json);

            action.Should().Throw<Exception>();
        }

        [Fact]
        public void HavingAMissingThrowsException()
        {
            var json = "{ }";
            Action action = () => Deserialise(json);

            action.Should().Throw<Exception>();
        }
    }
}
