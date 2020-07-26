namespace NullableSerialisationExperiments.SystemJsonTests
{
    public class DefaultBasedExpectationsTests
    : SystemJsonBasedTestsBase<DefaultBasedExpectationsTests.Implementation>
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