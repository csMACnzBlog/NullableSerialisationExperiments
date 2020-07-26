namespace NullableSerialisationExperiments.NewtonsoftTests
{
    public class DefaultBasedExpectationsTests
        : NewtonsoftBasedTestsBase<DefaultBasedExpectationsTests.Implementation>
    {
        /// <summary>
        /// This is expected to fail the null and missing checks
        /// </summary>
        public class Implementation : Interface
        {
            public string Value { get; set; } = default!;
        }
    }
}