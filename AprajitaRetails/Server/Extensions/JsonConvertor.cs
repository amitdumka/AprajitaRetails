using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AprajitaRetails.Server.Extensions
{
    public class CustomJsonConverterForNullableDateTime : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            //Console.WriteLine("Reading");
            Debug.Assert(typeToConvert == typeof(DateTime?));
            return reader.GetString() == "" ? null : reader.GetDateTime();
        }

        // This method will be ignored on serialization, and the default typeof(DateTime) converter is used instead.
        // This is a bug: https://github.com/dotnet/corefx/issues/41070#issuecomment-560949493
        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            //Console.WriteLine("Here - writing");

            if (!value.HasValue)
            {
                //writer.WriteStringValue("");
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(value.Value);
            }
        }
    }
}

