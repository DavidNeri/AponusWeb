using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

public class CustomDateTimeConverter : JsonConverter<DateTime?>
{
    private readonly string _formato = "dd/MM/yyyy HH:mm:ss";

    public override DateTime? Read(ref Utf8JsonReader reader, Type ConversionTipo, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string CadenaFechaHora = reader.GetString();
            if (DateTime.TryParseExact(CadenaFechaHora, _formato, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return date;
            }
        }
        return null;
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value?.ToString(_formato));
    }
}
