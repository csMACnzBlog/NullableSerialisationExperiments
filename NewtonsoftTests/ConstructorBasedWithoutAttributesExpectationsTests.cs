using System;

namespace NullableSerialisationExperiments.NewtonsoftTests
{
    public class ConstructorBasedWithoutAttributesExpectationsTests
        : NewtonsoftBasedTestsBase<ConstructorBasedWithoutAttributesExpectationsTests.Implementation>
    {
        public class Implementation : Interface
        {
            public Implementation(string value)
            {
                if(value is null) throw new ArgumentNullException(nameof(value));
                Value = value;
            }

            public string Value { get; set; }
        }
    }
}