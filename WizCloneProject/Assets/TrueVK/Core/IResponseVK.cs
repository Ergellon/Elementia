namespace TrueVK.Core
{
	using System.Collections.Generic;

	public interface IResponseVK {

		/// <summary>
		/// Gets the response dictionary.
		/// </summary>
		/// <value>A collection of key values pairs that are parsed from the response.</value>
		Dictionary<string, object> ResponseDictionary { get; }
		
		/// <summary>
		/// Gets the response string.
		/// </summary>
		/// <value>The raw response string.</value>
		string Response { get; }
		
		/// <summary>
		/// Gets the error code.
		/// </summary>
		/// <value>The error code from the response. If no error occured value is null or empty.</value>
		string ErrorCode { get; }

	}
}