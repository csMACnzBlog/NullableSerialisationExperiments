using System.Text.Json;

namespace NullableSerialisationExperiments.SystemJsonTests
{
    public abstract class SystemJsonBasedTestsBase<T>
    : StringPropertySerialisationExpectationsTests<T>
    where T : StringPropertySerialisationExpectationsTests<T>.Interface
    {
        public override T Deserialise(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}