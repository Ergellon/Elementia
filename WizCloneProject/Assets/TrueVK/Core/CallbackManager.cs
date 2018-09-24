namespace TrueVK.Core
{
	using System;
	using System.Collections.Generic;

	internal class CallbackManager {

		private IDictionary<string, object> _callbacks = new Dictionary<string, object>();

		/// <summary>
		/// Last added callback's id.
		/// </summary>
        private int _lastCallbackId;

		/// <summary>
		/// Adds the callback.
		/// </summary>
		/// <returns>The callback id.</returns>
		/// <param name="callback">Callback.</param>
		public string AddCallback(VKDelegate callback)
		{
			if (callback == null)
			{
				return null;
			}
			
			_lastCallbackId++;

			var id = _lastCallbackId.ToString();
			_callbacks.Add(id, callback);

			return id;
		}

		/// <summary>
		/// Invoke the callback by id.
		/// </summary>
		/// <param name="callbackId">Callback identifier.</param>
		/// <param name="response">Response.</param>
		public void OnCallCompleted(string callbackId, string response)
		{
			if (callbackId == null || response == null)
			{
				return;
			}
			
			object callbackObject;
			if (_callbacks.TryGetValue(callbackId, out callbackObject))
			{
				var callback = callbackObject as VKDelegate;

				if (callback != null)
				{
					var vKResponse = new VKResponse (response);
					callback(vKResponse);
				}

				_callbacks.Remove(callbackId);
			}
		}		
	}
}