using Newtonsoft.Json;

namespace NullableSerialisationExperiments.NewtonsoftTests
{
    public abstract class NewtonsoftBasedTestsBase<T>
    : StringPropertySerialisationExpectationsTests<T>
    where T : StringPropertySerialisationExpectationsTests<T>.Interface
    {
        public override T Deserialise(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}