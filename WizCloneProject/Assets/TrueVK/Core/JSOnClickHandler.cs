namespace TrueVK.Core
{
	using System;
	using UnityEngine;

	/// <summary>
	/// Class to reset JS click handler.
	/// </summary>
	public class JSOnClickHandler
	{
		private string _integrationMethodJs = "";

		public JSOnClickHandler()
		{
			Init();
		}
		
		/// <summary>
		/// Init this instance.
		/// </summary>
		public void Init()
		{
			_integrationMethodJs = StringFromFile("OnClickHandler");
			
			if (_integrationMethodJs == null)
			{
				#if !UNITY_EDITOR
				throw new Exception("Cannot initialize JSOnClickHandler javascript");
				#endif
			}
			Application.ExternalEval(_integrationMethodJs);
		}	

		/// <summary>
		/// Reset current JS click handler.
		/// </summary>
		public void CleanCurrentMouseUpHandler()
		{
			Application.ExternalCall("JSOnClickHandler.cleanCurrentOnClickHandler");
		}

		private string StringFromFile(string resourceName)
		{
			TextAsset ta = Resources.Load(resourceName) as TextAsset;
			return ta ? ta.text : null;			
		}
	}
}
