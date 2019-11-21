using AAStudio.Diploma.Args;
using AAStudio.Diploma.Services;
using AAStudio.Diploma.Views;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AAStudio.Diploma.Controllers
{
	[RequireComponent(typeof(LoginSceneView))]
	public class LoginSceneController : MonoBehaviour
	{
		#region data

		private LoginSceneView _view;

		#endregion

		#region implementation

		private void Start()
		{
			_view = GetComponent<LoginSceneView>();

			_view.OnLoginBtnClicked += OnLoginBtnClickedHandler;
		}

		private void OnDestroy()
		{
			_view.OnLoginBtnClicked -= OnLoginBtnClickedHandler;
		}

		private void OnLoginBtnClickedHandler(object sender, LoginEventArgs e)
		{
			//TODO add login logic here
			SceneManager.LoadScene(AppConstants.SceneNames.MainSceneName);
		}

		#endregion

	}
}
