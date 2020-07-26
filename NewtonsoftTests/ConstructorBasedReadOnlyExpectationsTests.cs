using System;
using Newtonsoft.Json;

namespace NullableSerialisationExperiments.NewtonsoftTests
{
    public class ConstructorBasedReadOnlyExpectationsTests
        : NewtonsoftBasedTestsBase<ConstructorBasedReadOnlyExpectationsTests.Implementation>
    {
        public class Implementation : Interface
        {
            public Implementation(string value)
            {
                if(value is null) throw new ArgumentNullException(nameof(value));
                Value = value;
            }

            [JsonProperty(Required = Required.Always)]
            public string Value { get; }
        }
    }
}