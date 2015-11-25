using System;
using System.IO;
using System.Text;
using Cirrious.CrossCore.Platform;
using Newtonsoft.Json;

namespace Rozklad.Mobile.Core
{
	public class MvxJsonConverter : IMvxJsonConverter, IMvxTextSerializer
	{
		private readonly JsonSerializer _jsonSerializer;

		public MvxJsonConverter()
		{
			_jsonSerializer = new JsonSerializer();
		}

		public T DeserializeObject<T>(string inputText)
		{
			using (var stringReader = new StringReader(inputText))
			{
				using (var jsonTextReader = new JsonTextReader(stringReader))
				{
					return this._jsonSerializer.Deserialize<T>(jsonTextReader);
				}
			}
		}

		public object DeserializeObject(Type type, string inputText)
		{
			using (var stringReader = new StringReader(inputText))
			{
				return _jsonSerializer.Deserialize(stringReader, type);
			}
		}

		public string SerializeObject(object toSerialise)
		{
			var sb = new StringBuilder();
			using (var stringWriter = new StringWriter(sb))
			{
				_jsonSerializer.Serialize(stringWriter, toSerialise);
			}

			return sb.ToString();
		}
	}
}
