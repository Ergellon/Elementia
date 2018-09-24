namespace TrueVK.Core
{
	using MiniJSON;
	using System.Collections.Generic;

	/// <summary>
	/// Response.
	/// </summary>
	public class VKResponse : IResponseVK {

		/// <summary>
		/// The raw response string.
		/// </summary>
		public string Response { get; private set; }

		/// <summary>
		/// A collection of key values pairs that are parsed from the response.
		/// </summary>
		public Dictionary<string, object> ResponseDictionary 
		{ 
			get 
			{
				if (_responseDictionary == null)
					_responseDictionary = Json.Deserialize (Response) as Dictionary<string, object>;
				
				return _responseDictionary;
			}
		}

		/// <summary>
		/// A collection of key values pairs that are parsed from the response.
		/// </summary>
		private Dictionary<string, object> _responseDictionary;

		/// <summary>
		/// The error code from the response. If no error occured value is null or empty.
		/// </summary>
		public string ErrorCode
		{
			get 
			{ 
				if (_errorCode != null)
					return _errorCode;
				
				object error;
				ResponseDictionary.TryGetValue("error", out error);
				
				if (error == null)
					return null;
				
				var dictionary = (error as Dictionary<string, object>);
				_errorCode = dictionary["error_code"].ToString();
				return _errorCode;
			}
		}

		/// <summary>
		/// The error code from the response. If no error occured value is null or empty.
		/// </summary>
		private string _errorCode;

		/// <summary>
		/// Constructor.
		/// </summary>
		public VKResponse(string response)
		{
			Response = response;
		}
	}
}