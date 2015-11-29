using System;
using System.IO;
using System.Text;
using Cirrious.CrossCore.Platform;
using Newtonsoft.Json;

namespace Rozklad.Mobile.Core
{
	public class MvxJsonConverter : IMvxJsonConverter, IMvxTextSerializer
	{
		private readonly JsonSerializer jsonSerializer;

		public MvxJsonConverter()
		{
			jsonSerializer = new JsonSerializer();
		}

		public T DeserializeObject<T>(string inputText)
		{
			using (var stringReader = new StringReader(inputText))
			{
				using (var jsonTextReader = new JsonTextReader(stringReader))
				{
					return jsonSerializer.Deserialize<T>(jsonTextReader);
				}
			}
		}

		public object DeserializeObject(Type type, string inputText)
		{
			using (var stringReader = new StringReader(inputText))
			{
				return jsonSerializer.Deserialize(stringReader, type);
			}
		}

		public string SerializeObject(object toSerialise)
		{
			var sb = new StringBuilder();
			using (var stringWriter = new StringWriter(sb))
			{
				jsonSerializer.Serialize(stringWriter, toSerialise);
			}

			return sb.ToString();
		}
	}
}
