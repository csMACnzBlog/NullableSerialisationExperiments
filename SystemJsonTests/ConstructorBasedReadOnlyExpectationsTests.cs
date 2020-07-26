using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NullableSerialisationExperiments.SystemJsonTests
{
    public class ConstructorBasedReadOnlyExpectationsTests
        : SystemJsonBasedTestsBase<ConstructorBasedReadOnlyExpectationsTests.Implementation>
    {
        /// <summary>
        /// Only works if you have a custom converter
        /// </summary>
        [JsonConverter(typeof(ImmutableConverter))]
        public class Implementation : Interface
        {
            public Implementation(string value)
            {
                if (value is null) throw new ArgumentNullException(nameof(value));
                Value = value;
            }

            //// https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-migrate-from-newtonsoft-how-to#required-properties
            //// No equivalent to [JsonProperty(Required = Required.Always)]
            public string Value { get; }
        }

        public class ImmutableConverter : JsonConverter<Implementation>
        {
            private readonly JsonEncodedText ValueName = JsonEncodedText.Encode("value");

            public override Implementation Read(
                ref Utf8JsonReader reader,
                Type typeToConvert,
                JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                };

                string? value = default;
                bool valueSet = false;

                // Get the first property.
                reader.Read();
                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }

                if (reader.ValueTextEquals(ValueName.EncodedUtf8Bytes))
                {
                    value = ReadProperty(ref reader, options);
                    valueSet = true;
                }
                else
                {
                    throw new JsonException();
                }

                reader.Read();
                //// Doesn't handle extra properties...

                if (reader.TokenType != JsonTokenType.EndObject)
                {
                    throw new JsonException();
                }

                return new Implementation(value);
            }

            private string ReadProperty(ref Utf8JsonReader reader, JsonSerializerOptions options)
            {
                Debug.Assert(reader.TokenType == JsonTokenType.PropertyName);

                reader.Read();
                
                return reader.GetString();
            }

            private void WriteProperty(Utf8JsonWriter writer, JsonEncodedText name, string stringValue, JsonSerializerOptions options)
            {
                writer.WritePropertyName(name);
                writer.WriteStringValue(stringValue);
            }

            public override void Write(
                Utf8JsonWriter writer,
                Implementation implementation,
                JsonSerializerOptions options)
            {
                writer.WriteStartObject();
                WriteProperty(writer, ValueName, implementation.Value, options);
                writer.WriteEndObject();
            }
        }
    }
}