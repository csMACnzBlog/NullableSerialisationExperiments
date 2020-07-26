using System;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace NullableSerialisationExperiments.NewtonsoftTests
{
    public class ConstructorBasedExpectationsTests
        : NewtonsoftBasedTestsBase<ConstructorBasedExpectationsTests.Implementation>
    {
        public class Implementation : Interface
        {
            public Implementation(string value)
            {
                if(value is null) throw new ArgumentNullException(nameof(value));
                Value = value;
            }

            [JsonProperty(Required = Required.Always)]
            public string Value { get; set; }
        }

        [Fact]
        public void HavingANullValueThrowsArgumentNullException()
        {
            var json = "{ \"value\": null }";
            Action action = () => JsonConvert.DeserializeObject<Implementation>(json);

            action.Should().ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void HavingAMissingThrowsArgumentNullException()
        {
            var json = "{ }";
            Action action = () => JsonConvert.DeserializeObject<Implementation>(json);

            action.Should().ThrowExactly<ArgumentNullException>();
        }
    }
}