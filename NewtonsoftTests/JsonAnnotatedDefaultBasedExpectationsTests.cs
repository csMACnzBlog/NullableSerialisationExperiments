using Newtonsoft.Json;

namespace NullableSerialisationExperiments.NewtonsoftTests
{
    public class JsonAnnotatedDefaultBasedExpectationsTests
        : NewtonsoftBasedTestsBase<JsonAnnotatedDefaultBasedExpectationsTests.Implementation>
    {
        public class Implementation : Interface
        {
            [JsonProperty(Required = Required.Always)]
            public string Value { get; set; } = default!;
        }
    }
}