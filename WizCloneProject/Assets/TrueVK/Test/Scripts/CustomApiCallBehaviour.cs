namespace TrueVK.Test
{
	using UnityEngine;
	using UnityEngine.UI;
	using System.Collections.Generic;
	using TrueVK.Core;

	public class CustomApiCallBehaviour : MonoBehaviour 
	{
		#region - Inspector Fields -

		/// <summary>
		/// Clear parameters button.
		/// </summary>
		public Button ClearParametersButton;

		/// <summary>
		/// Input for name of the method.
		/// </summary>
		public InputField MethodName;

		/// <summary>
		/// Parameters count text.
		/// </summary>
		public Text ParametersCountText;

		/// <summary>
		/// Slider for parameters Count.
		/// </summary>
		public Slider ParametersCount;

		/// <summary>
		/// JS call method button.
		/// REMARK: We use JS button insted of default, because JS button allows intercept user clicks so browser does not block pop-ups window.
		/// </summary>
		public JSButton CallMethodButton;

		/// <summary>
		/// Parameters for method.
		/// </summary>
		public VKParameterBehaviour[] Parameters;

		/// <summary>
		/// VK logger.
		/// </summary>
		public CanvasLog Logger;

		#endregion // Inspector Fields


		#region - Unity Lifecycle -

		// Use this for initialization
		public void Start () {
			ParametersCount.maxValue = Parameters.Length;
			ClearParametersButton.onClick.AddListener(() => HandleClearButtonClick());
			ParametersCount.onValueChanged.AddListener((f) => HandleParametersCountChanged());

			CallMethodButton.Click += (sender, e) => HandleCallMethodClick();
		}

		#endregion // Unity Lifecycle

		#region - Buttons Event Click Handlers -

		/// <summary>
		/// Handle clear button click.
		/// </summary>
		private void HandleClearButtonClick ()
		{
			ParametersCount.value = 0;
			foreach (var par in Parameters)
			{
				par.Name.text = "";
				par.Value.text = "";
			}
		}

		/// <summary>
		/// Handle changing parameters count.
		/// </summary>
		private void HandleParametersCountChanged ()
		{
			var value = ParametersCount.value;
			ParametersCountText.text = "Parameters count: " + value;

			for (int i = 0; i < Parameters.Length; i++)
			{
				Parameters[i].gameObject.SetActive(i < value);
			}
		}

		/// <summary>
		/// Handle call method click.
		/// </summary>
		private void HandleCallMethodClick ()
		{
			var parameters = new Dictionary<string, object>();	

			var paramsCount = ParametersCount.value;
			for (int i = 0; i < paramsCount; i++)
			{
				var vKParameterBehaviour = Parameters [i];
				parameters.Add(vKParameterBehaviour.Name.text, vKParameterBehaviour.Value.text);
			}
			
			VK.Call(VKMethodCallback, MethodName.text, parameters, true);
		}

		#endregion - Buttons Event Click Handlers -

		#region - VK Api Callbacks -


		/// <summary>
		/// VKs method callback.
		/// </summary>
		/// <param name="response">Response.</param>
		private void VKMethodCallback (IResponseVK response)
		{
			Logger.Log("\n" + response.Response);
		}

		#endregion - VK Api Callbacks -
	}
}
