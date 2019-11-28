using AAStudio.Diploma.Args;
using AAStudio.Diploma.Models;
using AAStudio.Diploma.ScriptableObjects;
using AAStudio.Diploma.Services;
using AAStudio.Diploma.Services.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace AAStudio.Diploma.Views
{
	public class ModelsSceneView : MonoBehaviour
	{
		[SerializeField] private GridLayoutGroup _gridLayout;
		[SerializeField] private AssetModelsData _modelsData;

		private AssetModel _lastClickedModel;
		private IAssetService _assetService;

		private async void Start()
		{
			_assetService = new LocalAssetService(_modelsData);

			var models = await _assetService.GetAssetModels();

			foreach(var model in models.Data)
			{
				var element = ModelGridElement.Create(_gridLayout.transform, model);
				element.OnInfoBtnClicked += ElementOnInfoBtnClicked;
			}
			SceneManager.sceneLoaded += SceneManagerOnSceneLoaded;
		}

		private void SceneManagerOnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			if (scene.name == AppConstants.SceneNames.ModelInfoSceneName)
			{
				SceneManager.SetActiveScene(scene);
				var obj = scene.GetRootGameObjects();
				foreach (var o in obj)
				{
					var view = o.GetComponent<ModelInfoSceneView>();
					if (view != null)
					{
						view.Init(_lastClickedModel);
						return;
					}
				}
			}
		}

		private void ElementOnInfoBtnClicked(object sender, TypedEventArgs<AssetModel> e)
		{
			_lastClickedModel = e.Data;
			SceneManager.LoadScene(AppConstants.SceneNames.ModelInfoSceneName,LoadSceneMode.Additive);
		}
	}
}
