using AAStudio.Diploma.Args;
using AAStudio.Diploma.Models;
using AAStudio.Diploma.Services;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace AAStudio.Diploma.Views
{
	public class ModelMainSceneElement : MonoBehaviour
	{

		#region data

		[SerializeField] private Text _modelName;
		[SerializeField] private Image _modelImage;
		[SerializeField] private Image _selectedImage;
		[SerializeField] private Button _modelInfoButton;
		private AssetModel _data;

		#endregion

		#region interface

		public event EventHandler<TypedEventArgs<AssetModel>> OnSelected;

		public static ModelMainSceneElement Create(Transform parent, AssetModel data)
		{
			if (parent == null)
			{
				Debug.LogError("ModelMainSceneElement:Create - Unable to create ModelGridElement: null parent");
				return null;
			}

			if (data == null)
			{
				Debug.LogError("ModelMainSceneElement:Create - Unable to create ModelGridElement: null AssetModel");
				return null;
			}

			var prefabPath = Path.Combine(AppConstants.FileNames.PrefabsFolderName,
				AppConstants.FileNames.ModelMainSceneElementPrefabName);
			var prefab = Resources.Load<ModelMainSceneElement>(prefabPath);
			if (prefab == null)
			{
				Debug.LogError($"ModelMainSceneElement:Create - Unable to load ModelGridElement prefab from {prefabPath}");
				return null;
			}

			ModelMainSceneElement res = GameObject.Instantiate(prefab, parent.transform);
			res._data = data;
			return res;
		}

		public void SetSelected(bool selected)
		{
			_selectedImage.gameObject.SetActive(selected);
		}

		#endregion

		#region implementation

		private void Awake()
		{
			SetSelected(false);
		}

		private void Start()
		{
			_modelName.text = _data.Name;
			_modelInfoButton.onClick.RemoveAllListeners();
			_modelInfoButton.onClick.AddListener(OnSelectBtnClick);

			var img = Resources.Load<Sprite>(_data.PreviewImagePath);

			if (img == null)
			{
				Debug.LogWarning($"ModelMainSceneElement:Start - Unable to load image from {_data.PreviewImagePath}");
			}
			else
			{
				_modelImage.sprite = img;
				_modelImage.preserveAspect = true;
			}

		}

		private void OnDestroy()
		{
			_modelInfoButton.onClick.RemoveListener(OnSelectBtnClick);
		}

		private void OnSelectBtnClick()
		{
			OnSelected?.Invoke(this, new TypedEventArgs<AssetModel>(_data));
		}

		#endregion

	}
}
