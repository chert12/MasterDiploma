using System;
using AAStudio.Diploma.Args;
using UnityEngine;
using UnityEngine.UI;

namespace AAStudio.Diploma.Views
{
	public class LoginSceneView : MonoBehaviour
	{
		#region data

		[SerializeField] private Button _loginBtn;
		[SerializeField] private InputField _emailInput;
		[SerializeField] private InputField _passwordInput;

		#endregion

		#region interface

		public event EventHandler<LoginEventArgs> OnLoginBtnClicked;

		#endregion

		#region implementation 

		private void Start()
		{
			_loginBtn.onClick.RemoveAllListeners();
			_loginBtn.onClick.AddListener(OnLoginBtnClick);
		}

		private void OnLoginBtnClick()
		{
			OnLoginBtnClicked?.Invoke(this, new LoginEventArgs(_emailInput.text, _passwordInput.text));
		}

		#endregion

	}
}
