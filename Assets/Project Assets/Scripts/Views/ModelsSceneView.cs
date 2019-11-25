using AAStudio.Diploma.ScriptableObjects;
using AAStudio.Diploma.Services;
using AAStudio.Diploma.Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace AAStudio.Diploma.Views
{
	public class ModelsSceneView : MonoBehaviour
	{
		[SerializeField] private GridLayoutGroup _gridLayout;
		[SerializeField] private AssetModelsData _modelsData;

		private IAssetService _assetService;

		private async void Start()
		{
			_assetService = new LocalAssetService(_modelsData);

			var models = await _assetService.GetAssetModels();

			foreach(var model in models.Data)
			{
				ModelGridElement.Create(_gridLayout.transform, model);
			}

		}

	}
}
