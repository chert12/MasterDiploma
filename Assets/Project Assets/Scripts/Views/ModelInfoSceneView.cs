using AAStudio.Diploma.Models;
using AAStudio.Diploma.ScriptableObjects;
using AAStudio.Diploma.Services;
using UnityEngine;
using UnityEngine.UI;

namespace AAStudio.Diploma.Views
{
	public class ModelInfoSceneView : BaseView
	{

		#region data

		[SerializeField] private Image _modelPreviewImage;
		[SerializeField] private Text _modelNameText;
		[SerializeField] private Text _modelDescriptionText;
		[SerializeField] private Text _modelCredentialsText;

		#endregion

		#region interface

		public void Init(AssetModel model)
		{
			_modelNameText.text = model.Name;
			_modelDescriptionText.text = model.Description;
			_modelCredentialsText.text = model.Credentials;
            SceneToSetActive = AppConstants.SceneNames.ModelsSceneName;

			var s = Resources.Load<Sprite>(model.PreviewImagePath);

			if (s != null)
			{
				_modelPreviewImage.sprite = s;
			}
		}

		#endregion
	}
}
