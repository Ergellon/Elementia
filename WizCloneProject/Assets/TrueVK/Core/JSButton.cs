namespace TrueVK.Core
{
	using UnityEngine;
	using UnityEngine.EventSystems;
	using System;

	/// <summary>
	/// Class to intercept the user clicks so browser does not block pop-ups windows.
	/// </summary>
	public class JSButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

		/// <summary>
		/// Occurs when user click.
		/// </summary>
		public event EventHandler Click;

		/// <summary>
		/// Handler for jsButton.
		/// </summary>
		private JSOnClickHandler _jsClickHandler;

		/// <summary>
		/// Gets a value indicating whether current platform is WebGL.
		/// </summary>
		private bool _isWebGl;

		public void Start()
		{
			_isWebGl = true;
		#if !UNITY_WEBGL
			_isWebGl = false;
			gameObject.AddComponent<UnityEngine.UI.Button>();
			GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => OnClick());
		#endif
			
			_jsClickHandler = new JSOnClickHandler();
		}
		
		#region IPointerEnterHandler implementation
		
		public void OnPointerEnter (PointerEventData eventData)
		{
			if (_isWebGl)
			{
				OnClick();
			}
		}
		
		#endregion
		
		#region IPointerExitHandler implementation
		
		public void OnPointerExit (PointerEventData eventData)
		{
			if (_isWebGl)
			{
				_jsClickHandler.CleanCurrentMouseUpHandler();
			}
		}
		
		#endregion

		public void OnDisable()
		{
			if (_isWebGl)
			{
				_jsClickHandler.CleanCurrentMouseUpHandler();
			}
		}

		/// <summary>
		/// Raises the click event.
		/// </summary>
		private void OnClick ()
		{
			var e = Click;
			if (e != null)
				e(this, EventArgs.Empty);
		}
	}
}