namespace TrueVK.Core
{
	using UnityEngine;
	using System;
	using System.Collections.Generic;
	using MiniJSON;
	using System.Collections;

	/// <summary>
	/// Wrapper for accessing VK Open Api.
	/// </summary>
	public class VKProvider : MonoBehaviour {

		#region - Consts -

		/// <summary>
		/// Resource name with JS functions Api.
		/// </summary>
		private const string JSResourceName = "VKOpenAPIBinding";

		private const string LoginFunctionName = "VKUnity.login";
		private const string InitFunctionName = "VKUnity.init";
		private const string LogoutFunctionName = "VKUnity.logout";
		private const string CallFunctionName = "VKUnity.call";

		#endregion
		
		#region - Fields -
		
		private VKDelegate _loginCallback;
		private VKDelegate _logoutCallback;
		private CallbackManager _callbackManager = new CallbackManager();
		
		#endregion
		
		#region - Public Methods -
		
		/// <summary>
		/// Initialization VK Open Api.
		/// </summary>
		/// <param name="appId">App identifier.</param>
		/// <param name="status">Automatic update of session and status data using VK.Auth.getLoginStatus method during initialization.</param>
		/// <param name="useJsButtons">Set true if need use JSButton to intercept the user clicks so browser does not block pop-ups windows.</param>
		public void Init(string appId, bool status, bool useJsButtons)
		{			
			bool isPlayer = true;
			#if UNITY_WEBGL
			isPlayer = false;
			#endif
			
			var integrationMethodJs = StringFromFile(JSResourceName);
			
			if (integrationMethodJs == null)
			{
				#if !UNITY_EDITOR
				throw new Exception("Cannot initialize vk javascript");
				#endif
			}
			
			Application.ExternalEval(integrationMethodJs);
			Application.ExternalCall (InitFunctionName,
			                          isPlayer ? 1 : 0,
			                          appId,
			                          status,
			                          useJsButtons ? 1 : 0);
		}
		
		/// <summary>
		/// Authorize user.
		/// </summary>
		/// <param name="callback">Callback.</param>
		/// <param name="settings">Application access permissions.</param>
		public void Login(VKDelegate callback, string settings)
		{
			_loginCallback = callback;
			Application.ExternalCall(LoginFunctionName, settings);
		}

		/// <summary>
		/// Logout.
		/// </summary>
		/// <param name="callback">Callback.</param>
		public void Logout(VKDelegate callback)
		{
			_logoutCallback = callback;
			Application.ExternalCall(LogoutFunctionName);
		}

		/// <summary>
		/// Calls a method passed in method parameter with arguments passed in params object. VK API server response is returned as an argument in function call specified in callback parameter.
		/// </summary>
		/// <param name="callback">Callback.</param>
		/// <param name="method">Method.</param>
		/// <param name="parameters">Parameters.</param>
		/// <param name="needConfirm">True if method require confirmation window.</param>
		public void Call(VKDelegate callback, string method, IDictionary parameters, bool needConfirm)
		{
			var callback_id = _callbackManager.AddCallback(callback);

			var param = Json.Serialize(parameters);		
			Application.ExternalCall(CallFunctionName, 
			                         callback_id,
			                         method, param,
			                         needConfirm ? 1 : 0);
		}
		#endregion
		
		#region - Private Methods -

		/// <summary>
		/// Get string from file.
		/// </summary>
		/// <returns>Result string.</returns>
		/// <param name="resourceName">Resource name.</param>
		private static string StringFromFile(string resourceName)
		{
			var textAsset = Resources.Load(resourceName) as TextAsset;
			return textAsset ? textAsset.text : null;		
		}

		#endregion

		#region - JS Callbacks -


		/// <summary>
		/// Call the login complete callback.
		/// </summary>
		/// <param name="response">Response.</param>
		private void OnLoginComplete(string response)
		{
			if (_loginCallback != null) {
				_loginCallback (new VKResponse (response));
			}
		}

		/// <summary>
		/// Call the logout complete callback.
		/// </summary>
		private void OnLogoutComplete()
		{
			if (_logoutCallback != null)
				_logoutCallback(new VKResponse(string.Empty)); 
		}

		/// <summary>
		/// Call the complete callback.
		/// </summary>
		/// <param name="response">Response.</param>
		private void OnCallComplete(string response)
		{
			var result = Json.Deserialize(response) as Dictionary<string, object>;

			var callback_id = result["callback_id"] as string;
			var res = result["response"] as string;
			_callbackManager.OnCallCompleted(callback_id, res);
		}

		#endregion
	}
}