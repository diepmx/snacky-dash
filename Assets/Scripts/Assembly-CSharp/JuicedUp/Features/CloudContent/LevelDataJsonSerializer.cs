using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JuicedUp.Features.CloudContent
{
	public static class LevelDataJsonSerializer
	{
		private sealed class LevelDataSoContractResolver : DefaultContractResolver
		{
			private static readonly HashSet<string> LevelDataSoIgnored;

			protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
			{
				return null;
			}
		}

		internal static readonly JsonSerializerSettings Settings;

		public static string ToJson(LevelDataSO source)
		{
			return null;
		}

		public static string ToJson<T>(T value) where T : class
		{
			return null;
		}

		public static LevelDataSO FromJson(string json, string name = "Remote_Level")
		{
			return null;
		}

		public static T FromJson<T>(string json) where T : class
		{
			return null;
		}

		private static string StripBom(string json)
		{
			return null;
		}
	}
}
