namespace TrueVK.Test
{
	using UnityEngine;
	using UnityEngine.UI;

	public class CanvasLog : MonoBehaviour {

		public Text LogText;

		/// <summary>
		/// Add text to log.
		/// </summary>
		public void Log(string text)
		{
			LogText.text += text + "\n";
		}
	}
}