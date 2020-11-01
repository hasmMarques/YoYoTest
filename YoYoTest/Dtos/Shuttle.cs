using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YoYoTest.Dtos
{
	public partial class Shuttle
	{
		#region Properties

		[JsonProperty("AccumulatedShuttleDistance", Required = Required.Always)]
		[JsonConverter(typeof(ParseStringConverter))]
		public long AccumulatedShuttleDistance { get; set; }

		[JsonProperty("SpeedLevel", Required = Required.Always)]
		[JsonConverter(typeof(ParseStringConverter))]
		public long SpeedLevel { get; set; }

		[JsonProperty("ShuttleNo", Required = Required.Always)]
		[JsonConverter(typeof(ParseStringConverter))]
		public long ShuttleNo { get; set; }

		[JsonProperty("Speed", Required = Required.Always)]
		public string Speed { get; set; }

		[JsonProperty("LevelTime", Required = Required.Always)]
		public string LevelTime { get; set; }

		[JsonProperty("CommulativeTime", Required = Required.Always)]
		public string CommulativeTime { get; set; }

		[JsonProperty("StartTime", Required = Required.Always)]
		public string StartTime { get; set; }

		[JsonProperty("ApproxVo2Max", Required = Required.Always)]
		public string ApproxVo2Max { get; set; }

		#endregion
	}

	public partial class Shuttle
	{
		#region Public Methods

		public static List<Shuttle> FromJson(string json) =>
			JsonConvert.DeserializeObject<List<Shuttle>>(json, Converter.Settings);

		#endregion
	}

	public static class Serialize
	{
		#region Public Methods

		public static string ToJson(this List<Shuttle> self) =>
			JsonConvert.SerializeObject(self, Converter.Settings);

		#endregion
	}

	internal static class Converter
	{
		#region Fields

		public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
		{
			MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
			DateParseHandling = DateParseHandling.None,
			Converters =
			{
				new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}
			},
		};

		#endregion
	}

	internal class ParseStringConverter : JsonConverter
	{
		#region Fields

		public static readonly ParseStringConverter Singleton = new ParseStringConverter();

		#endregion

		#region Public Methods

		public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

		public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null) return null;
			var value = serializer.Deserialize<string>(reader);
			long l;
			if (Int64.TryParse(value, out l))
			{
				return l;
			}

			throw new Exception("Cannot unmarshal type long");
		}

		public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
		{
			if (untypedValue == null)
			{
				serializer.Serialize(writer, null);
				return;
			}

			var value = (long) untypedValue;
			serializer.Serialize(writer, value.ToString());
		}

		#endregion
	}
}