using AAStudio.Diploma.Services;
using AAStudio.Diploma.Views;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AAStudio.Diploma.Controllers
{
	[RequireComponent(typeof(MainSceneView))]
	public class MainSceneController : MonoBehaviour
	{

		#region data

		private MainSceneView _view;

		#endregion

		#region implementation

		private void Start()
		{
			_view = GetComponent<MainSceneView>();
			_view.OnNavigationDrawerButtonClicked += NavigationDrawerBtnHandler;
		}

		private void OnDestroy()
		{
			_view.OnNavigationDrawerButtonClicked -= NavigationDrawerBtnHandler;
		}

		private void NavigationDrawerBtnHandler(object sender, Args.TypedEventArgs<Enums.NavigationDrawerButton> args)
		{
			if (args == null)
			{
				Debug.LogWarning("MainSceneController.NavigationDrawerBtnHandler: Unable to handle click - null arguments");
				return;
			}

			if (args.Error != null)
			{
				Debug.LogWarning($"MainSceneController.NavigationDrawerBtnHandler: Error - {args.Error.Message}");
				return;
			}

			if (args.Cancelled)
			{
				Debug.LogWarning("MainSceneController.NavigationDrawerBtnHandler: Async operation canceled");
				return;
			}

			switch (args.Data)
			{
				case Enums.NavigationDrawerButton.AllModels:
					{
						PopUp.Create(_view.Ui.transform, "INFO", "All Models");
						break;
					}
				case Enums.NavigationDrawerButton.MyModels:
					{
						PopUp.Create(_view.Ui.transform, "INFO", "My Models");
						break;
					}
				case Enums.NavigationDrawerButton.MyClasses:
					{
						break;
					}
				case Enums.NavigationDrawerButton.Settings:
					{
						SceneManager.LoadScene(AppConstants.SceneNames.SettingsSceneName, LoadSceneMode.Additive);
						break;
					}
				case Enums.NavigationDrawerButton.About:
					{
						break;
					}
			}
		}

		#endregion
	}
}
