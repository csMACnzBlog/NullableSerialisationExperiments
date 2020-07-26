using System;

namespace NullableSerialisationExperiments.SystemJsonTests
{
    public class ConstructorBasedExpectationsTests
        : SystemJsonBasedTestsBase<ConstructorBasedExpectationsTests.Implementation>
    {
        public class Implementation : Interface
        {
            /// <summary>
            /// This is expected to fail because deserialization of reference types without parameterless constructor is not supported.
            /// </summary>
            /// <param name="value"></param>
            public Implementation(string value)
            {
                if (value is null) throw new ArgumentNullException(nameof(value));
                Value = value;
            }

            //// https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-migrate-from-newtonsoft-how-to#required-properties
            //// No equivalent to [JsonProperty(Required = Required.Always)]
            public string Value { get; set; }
        }
    }
}