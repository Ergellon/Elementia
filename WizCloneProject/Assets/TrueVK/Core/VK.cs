namespace TrueVK.Core
{
	using System;
	using System.Linq;
    using UnityEngine;
	using System.Collections.Generic;

	/// <summary>
	/// Static class for accessing VK Api.
	/// </summary>
    public static class VK
    {
	#region - Consts -

		/// <summary>
		/// The API version.
		/// </summary>
		public const string ApiVersion = "5.40";

		/// <summary>
		/// The gameobject's name, to which will be added necessary scripts.
		/// </summary>
		private const string GameObjectName = "VKProvider";

	#endregion

	#region - Properties -

	/// <summary>
	/// Gets a value indicating whether SDK is initialized.
	/// </summary>
	public static bool IsInitialized { get; private set; }

	/// <summary>
	/// Gets a value that indicates if is platform supported.
	/// Supported platforms - WebGL and WebPlayer.
	/// </summary>
	/// <value><c>true</c> if is platform supported; otherwise, <c>false</c>.</value>
	private	static bool IsPlatformSupported
	{
		get
		{
			var isPlatformSupported = true;
			#if UNITY_EDITOR || !(UNITY_WEBPLAYER || UNITY_WEBGL)
			isPlatformSupported = false;
			#endif

			return isPlatformSupported;
		}
	}

	#endregion
		
	#region - Fields -

		/// <summary>
		/// The gameobject, to which will be added necessary scripts.
		/// </summary>
		private static GameObject _vkGameObject;

		/// <summary>
		/// Wrapper for accessing VK Open Api.
		/// </summary>
		private static VKProvider _vkProvider;

	#endregion
	
	#region - Public Methods -

        /// <summary>
        /// Initialize VK.
        /// </summary>
		public static void Init(string appId, bool status = false, bool useJsButtons = true)
        {
			if (!IsPlatformSupported)
			{
				ShowSupportedPlatformMessage();
				return;
			}

			if (string.IsNullOrEmpty(appId))
			{
				throw new Exception("AppId is null or empty");
			}

			if (_vkGameObject == null)
			{
				_vkGameObject = new GameObject(GameObjectName);
			}			
			
			_vkProvider = _vkGameObject.GetComponent<VKProvider>();
			if (_vkProvider == null)
			{
				_vkProvider = _vkGameObject.AddComponent<VKProvider>();
			}

			_vkProvider.Init(appId, status, useJsButtons);

			IsInitialized = true;
        }

		/// <summary>
		/// Opens a pop-up window for user authorization with its VK account.
		/// </summary>
		/// <param name="callback">Callback.</param>
		/// <param name="permissions">User settings of the application are compared to the value passed in settings, and if needed, missing settings are requested.</param>
		public static void Login(VKDelegate callback, params Permissions[] permissions)
		{
			if (!IsPlatformSupported)
			{
				ShowSupportedPlatformMessage();
				return;
			}

			if (!IsInitialized)
				return;

			var permissionsArray = permissions.Distinct().ToArray();

			var settings = 0;
			foreach (var permission in permissionsArray)
			{
				settings += (int)permission;
			}
			_vkProvider.Login(callback, settings.ToString());
		}

		/// <summary>
		/// Logout. If successful, it ends user session inside Open API platform.
		/// </summary>
		/// <param name="callback">Callback.</param>
		public static void Logout(VKDelegate callback)
		{
			if (!IsPlatformSupported)
			{
				ShowSupportedPlatformMessage();
				return;
			}

			if (!IsInitialized)
				return;

			_vkProvider.Logout(callback);			
		}

		/// <summary>
		/// You can use call method of VK.Api object to interact with VK Flash API.
		/// </summary>
		/// <param name="method">Method.</param>
		/// <param name="parameters">Parameters.</param>
		/// <param name="callback">Callback.</param>
		/// <param name="needConfirm"></para>Method requires using the confirmation window.</param>
		public static void Call(VKDelegate callback, string method, Dictionary<string, object> parameters, bool needConfirmationWindow = false)
		{
			if (!IsPlatformSupported)
			{
				ShowSupportedPlatformMessage();
				return;
			}

			if (!IsInitialized)
				return;

			if (parameters == null)
				return;

			parameters.Add("version", ApiVersion);

			_vkProvider.Call(callback, method, parameters, needConfirmationWindow);
		}

		#endregion

		#region - Private Methods -

		/// <summary>
		/// Show to user warning message.
		/// </summary>
		private static void ShowSupportedPlatformMessage ()
		{
			Debug.LogWarning ("TrueVK supports only WebGL and WebPlayer platform");
		}

		#endregion
    }
}
